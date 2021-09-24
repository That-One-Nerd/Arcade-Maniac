using System;
using System.Linq;
using UnityEngine;

namespace That_One_Nerd.Unity.Games.ArcadeManiac.Misc.Handlers
{
    public class PoolHandler
    {
        public int PooledObjectCount => Pool.childCount;
        public GameObject[] PooledObjects
        {
            get
            {
                GameObject[] objects = new GameObject[Pool.childCount];
                for (int i = 0; i < Pool.childCount; i++) objects[i] = Pool.GetChild(i).gameObject;
                return objects;
            }
        }
        public int UsedObjectCount => TotalObjectCount - PooledObjectCount;
        public int TotalObjectCount => UnityEngine.Object.FindObjectsOfType<PoolObject>().Where(x => x.Handler == this).Count();

        public Transform Pool
        {
            get => p_Pool;
            set
            {
                Transform possible = p_Pool == null ? value : p_Pool;
                GameObject[] objects = new GameObject[possible.childCount];
                for (int i = 0; i < possible.childCount; i++) objects[i] = possible.GetChild(i).gameObject;
                Deposit(value, objects);

                p_Pool = value;
            }
        }

        private Transform p_Pool;

        public PoolHandler(Transform pool) => Pool = pool;

        public GameObject Aquire(Transform t) => Aquire(t, 1)[0];
        public GameObject[] Aquire(Transform t, int amount)
        {
            if (PooledObjectCount < amount) throw new Exception("There are not enough objects in the pool to aquire");
            Transform[] children = new Transform[amount];
            for (int i = 0; i < amount; i++) children[i] = Pool.GetChild(i);

            GameObject[] poolObjects = new GameObject[amount];
            for (int i = 0; i < children.Length; i++)
            {
                poolObjects[i] = children[i].gameObject;
                poolObjects[i].SetActive(true);
                poolObjects[i].transform.SetParent(t);
            }

            return poolObjects;
        }
        public void Deposit(params GameObject[] objects) => Deposit(Pool, objects);
        private void Deposit(Transform pool, params GameObject[] objects)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].transform.SetParent(pool);
                PoolObject[] poolObjs = objects[i].GetComponents<PoolObject>();
                if (poolObjs == null || !poolObjs.Any(x => x.Handler == this))
                {
                    PoolObject obj = objects[i].AddComponent<PoolObject>();
                    obj.Handler = this;
                }

                objects[i].SetActive(false);
            }
        }

        public class PoolObject : MonoBehaviour
        {
            public PoolHandler Handler { get; internal set; }
        }
    }
}
