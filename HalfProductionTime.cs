using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Rock.Unity;
using System.Threading.Tasks;

namespace HalfProductionTime
{
    public class HalfProductionTime : GameMod
    {
        // Token: 0x06000004 RID: 4 RVA: 0x00002110 File Offset: 0x00000310
        public override void Load()
        {
            System.Version version = typeof(HalfProductionTime).Assembly.GetName().Version;
            SceneManager.sceneLoaded += OnSceneLoaded;
            Debug.Log(string.Format("HalfProductionTime loaded: {0}, build time: {1}", version, File.GetLastWriteTime(typeof(HalfProductionTime).Assembly.Location).ToShortTimeString()));
        }

        public override void Unload()
        {
            foreach (Recipe recipe in GameResources.Instance.Recipes)
            {
                recipe.ProductionTime *= 2;
            }
        }

        // Token: 0x06000005 RID: 5 RVA: 0x0000217C File Offset: 0x0000037C
        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            if (arg0.name == "Island")
            {
                foreach (Recipe recipe in GameResources.Instance.Recipes)
                {
                    recipe.ProductionTime /= 2;
                }
            }
        }
        private bool onSceneLoadedDone;
    }
}
