using System.IO;
using UnityEngine;

public class MasterHand : MonoBehaviour {

    public GameObject[] prefabs;
    public GameObject[] gameObjects;
    public GameObject obj, floor;
    public GameObject Sun, MidLight, SmallLight, cam;
    public Material Mat1, Mat2, sky, DepthMap,Matn;
    public GameObject h1, h2;
    public float lx, ly, lz, mx, my, mz,cutofft,rad;
    Vector3 Campos;
    int sk;
    public int start, stop;
    public Transform[] Points;
    public points point;
    private void Start() 
    {
        MasterM();
        string z = "C:/Users/abdul/Desktop/Hand/Data/T/" + start + ".jpg";
        ScreenCapture.CaptureScreenshot(z);
        start = start + 1;
        //point.generateString();
        InvokeRepeating("refresh", 1f, 0.25f);
    }
    void refresh()
    {
        MasterM();
        Light();
        hconfig1();
    }
    private void hconfig1()
    {
        
        Vector3 Position = new Vector3(Random.Range(lx, mx), Random.Range(ly, my), Random.Range(lz, mz));
        GameObject g;
        g =Instantiate(h2, Position,Quaternion.identity);
        string z = "C:/Users/abdul/Desktop/Hand/Data/T/" + start + ".jpg";
        ScreenCapture.CaptureScreenshot(z);
        start=start+1;
        //point = g.GetComponent<points>();
        //point.generateString();
        gameObjects = GameObject.FindGameObjectsWithTag("Hand");
        Destroy(gameObjects[0]);
        
    }

    private void MasterM()
    {
        Light();
        sk = Random.Range(1, 185);
        DestroyAll();
        Resources.UnloadUnusedAssets();
        byte[] fileData;
        string filepath = "C:/Users/abdul/OneDrive/Documents/GAN/Assets/Prefabs/Light/floor textures _ Google Search/1 (" + sk + ").jpg";
        Texture2D tex;
        fileData = File.ReadAllBytes(filepath);
        tex = new Texture2D(2, 2);
        tex.LoadImage(fileData);
        Renderer rend = floor.GetComponent<Renderer>();
        rend.material.SetTexture("_MainTex", tex);
        BigObj();
        MidObj();
        SmallObj();
        SmallObj();


    }
 /*   void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        for (int i = 0; i < Points.Length; i++)
        {
            Gizmos.DrawSphere(Points[i].position, rad);

        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(Points[0].position, Points[1].position);
        Gizmos.DrawLine(Points[1].position, Points[2].position);
        Gizmos.DrawLine(Points[2].position, Points[20].position);
        Gizmos.DrawLine(Points[3].position, Points[4].position);
        Gizmos.DrawLine(Points[4].position, Points[5].position);
        Gizmos.DrawLine(Points[5].position, Points[6].position);
        Gizmos.DrawLine(Points[6].position, Points[20].position);
        Gizmos.DrawLine(Points[7].position, Points[8].position);
        Gizmos.DrawLine(Points[8].position, Points[9].position);
        Gizmos.DrawLine(Points[9].position, Points[10].position);
        Gizmos.DrawLine(Points[10].position, Points[20].position);
        Gizmos.DrawLine(Points[11].position, Points[12].position);
        Gizmos.DrawLine(Points[12].position, Points[13].position);
        Gizmos.DrawLine(Points[13].position, Points[14].position);
        Gizmos.DrawLine(Points[14].position, Points[19].position);
        Gizmos.DrawLine(Points[15].position, Points[16].position);
        Gizmos.DrawLine(Points[16].position, Points[17].position);
        Gizmos.DrawLine(Points[17].position, Points[18].position);
        Gizmos.DrawLine(Points[18].position, Points[20].position);
    }*/
    private void BigObj()
    {
        int n;
        n = Random.Range(1, 6);
        for (int k = 0; k < n; k++)
        {
            int i;
            float l = Random.Range(5.0f, 20.0f);
            Vector3 position = new Vector3(Random.Range(-30.0f, 30.0f)+3, 0.5f * l, Random.Range(20f, 100.0f) / 2 +3);
            i = Random.Range(0, prefabs.Length);
            obj = Instantiate(prefabs[i], position, Quaternion.identity);
            Transform trans = obj.GetComponent<Transform>();
            Renderer rend = obj.GetComponent<Renderer>();
            rend.material.SetFloat("_Metallic", Random.Range(0.00f, 1.00f));
            rend.material.SetFloat("_Glossiness", Random.Range(0.00f, 1.00f));
            rend.material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

            trans.localScale = new Vector3(Random.Range(5f, 20.0f), l, Random.Range(5f, 20.0f));
            Vector3 Angle = new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
            trans.Rotate(Angle);


        }
    }
    private void MidObj()
    {
        int n;
        n = Random.Range(0, 6);
        for (int k = 0; k < n; k++)
        {
            int i;
            float l = Random.Range(0f, 5f);
            Vector3 position = new Vector3(Random.Range(-5.0f, 5.0f), 0.5f * l, Random.Range(0f, 5.0f)+3);
            i = Random.Range(0, prefabs.Length);
            obj = Instantiate(prefabs[i], position, Quaternion.identity);
            Renderer rend = obj.GetComponent<Renderer>();
            rend.material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            rend.material.SetFloat("_Metallic", Random.Range(0.00f, 1.00f));
            rend.material.SetFloat("_Glossiness", Random.Range(0.00f, 1.00f));
            Transform trans = obj.GetComponent<Transform>();
            trans.localScale = new Vector3(Random.Range(0f, 5.0f), l, Random.Range(0f, 5.0f));
            Vector3 Angle = new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
            trans.Rotate(Angle);
        }

    }
    private void SmallObj()
    {
        int n;
        n = Random.Range(0, 8);
        for (int k = 0; k < n; k++)
        {
            int i;
            float l = Random.Range(0f, 2f);
            Vector3 position = new Vector3(Random.Range(-5.0f, 5.0f), 0.5f * l, Random.Range(0f, 10.0f)+3);
            i = Random.Range(0, prefabs.Length);
            obj = Instantiate(prefabs[i], position, Quaternion.identity);
            Renderer rend = obj.GetComponent<Renderer>();
            rend.material.SetFloat("_Metallic", Random.Range(0.00f, 1.00f));
            rend.material.SetFloat("_Glossiness", Random.Range(0.00f, 1.00f));
            rend.material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            Transform trans = obj.GetComponent<Transform>();
            trans.localScale = new Vector3(Random.Range(0.5f, 2f), l, Random.Range(0.5f, 2f));
            Vector3 Angle = new Vector3(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
            trans.Rotate(Angle);
        }

    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            DestroyAll();
        }
        if (Input.GetButton("Fire2"))
        {
            Campos = cam.transform.position;
            hconfig1();
            MasterM();
        }

    }
    void DestroyAll()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Respawn");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
        gameObjects = GameObject.FindGameObjectsWithTag("Light");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
    }
    void Light()
    {
        int j;
        j = Random.Range(1, 10);
        if (j >= 7)
        { print("Light");
            RenderSettings.skybox = Mat1;
            RenderSettings.skybox.SetFloat("_AtmosphereThickness", Random.Range(0.2f, 2.5f));
            int posx, posz, k;
            posx = Random.Range(-40, 40);
            posz = Random.Range(-50, 50);
            Vector3 sunpos;
            sunpos = new Vector3(posx, 100, posz);
            GameObject SUN = Instantiate(Sun, sunpos, Quaternion.identity);
            k = Random.Range(0, prefabs.Length);
            Transform sun_trans = SUN.transform.GetChild(0);
            sun_trans.LookAt(prefabs[k].GetComponent<Transform>());
        }
        if (j >= 5 && j < 7)
        {
            RandSky();

        }
        int lprob = Random.Range(1, 10);
        if (lprob > 5)
        {
            lprob = lprob - 5;
            for (int i = 0; i <= lprob; i++)
            {
                Instantiate(MidLight, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }


        lprob = lprob - 3;
        for (int i = 0; i <= lprob; i++)
        {
            Instantiate(SmallLight, new Vector3(0, 0, 0), Quaternion.identity);
        }

    }
    void RandSky()
    {
        byte[] fileData;
        RenderSettings.skybox = Mat2;
        int s = Random.Range(1000, 1119);
        string filepath = "C:/Users/abdul/OneDrive/Documents/GAN/Assets/Prefabs/Light/Backimgs/" + s + ".jpg";
        Texture2D tex;
        //AssetDatabase.CreateAsset(tex, "C:/Users/abdul/OneDrive/Documents/GAN/Assets/Prefabs/Light/Backimgs/"+s+".jpg");
        fileData = File.ReadAllBytes(filepath);
        tex = new Texture2D(2, 2);
        tex.LoadImage(fileData);
        RenderSettings.skybox.SetTexture("_BackTex", tex);
        RenderSettings.skybox.SetTexture("_LeftTex", tex);
        RenderSettings.skybox.SetTexture("_RightTex", tex);
        RenderSettings.skybox.SetTexture("_UpTex", tex);
        RenderSettings.skybox.SetTexture("_DownTex", tex);
        RenderSettings.skybox.SetTexture("_FrontTex", tex);

    }
    //Not Used
    //Depth Map Creation
    // void Depth()
    // {

    //     Collider coll;
    //     gameObjects = GameObject.FindGameObjectsWithTag("Light");

    //     for (var i = 0; i < gameObjects.Length; i++)
    //     {
    //         Destroy(gameObjects[i]);
    //     }
    //     RenderSettings.skybox = sky;
    //     gameObjects = GameObject.FindGameObjectsWithTag("Respawn");
    //     float clr;
    //     Color c;
    //     for (var i = 0; i < gameObjects.Length; i++)
    //     {
    //         coll = gameObjects[i].GetComponent<Collider>();
    //         Vector3 closestPoint = coll.ClosestPointOnBounds(Campos);
    //         float distance = Vector3.Distance(closestPoint, Campos);
    //         clr = (distance) / 20;
    //         if (clr > 1)
    //         {
    //             clr = 1;
    //         }
    //         if (distance == 0)
    //             clr = 1 / 255;
    //         gameObjects[i].GetComponent<MeshRenderer>().material = DepthMap;
    //         Renderer rend = gameObjects[i].GetComponent<Renderer>();
    //         rend.material.SetFloat("_Metallic", 0.0f);
    //         rend.material.SetFloat("_Glossiness", 0.0f);
    //         c = new Color(clr, clr, clr);
    //         rend.material.color = c;

    //     }
    // }
}
