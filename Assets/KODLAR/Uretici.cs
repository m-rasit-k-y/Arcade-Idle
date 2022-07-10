using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uretici : MonoBehaviour
{
    public GameObject MoneyPrefab;
    public float Kac_Saniyede_Artsin;

    private float MaxSayi = 108;
    private float Counter;
    private float Xpozisyon;
    private float Zpozisyon;
    private float Ypozisyon;
    private Vector3 pozisyon;

    private void OnEnable()
    {
        InvokeRepeating("ParaArtirma", Kac_Saniyede_Artsin, Kac_Saniyede_Artsin);
    }


    public void ParaArtirma()
    {
        if (MaxSayi >= transform.childCount)
        {

            if (Counter == 0)
            {
                Xpozisyon = 1.7f;
                Zpozisyon = 0;
                Ypozisyon = 1.84f;
            }
            if (Counter == 6)
            {
                Xpozisyon = 1.7f;
                Ypozisyon =  0.7f;
            }
            if (Counter == 12)
            {
                Xpozisyon = 1.7f;
                Ypozisyon = -0.45f;
            }
            if (Counter == 18)
            {
                Xpozisyon = 1.7f;
                Zpozisyon =  0.28f;
                Ypozisyon = 1.84f;
                Counter = 0;
            }
            if (transform.childCount == 36)
            {
                Zpozisyon = + 0.56f;
            }
            if (transform.childCount == 54)
            {
                Zpozisyon =  + 0.84f;
            }
            if (transform.childCount == 72)
            {
                Zpozisyon =  + 1.12f;
            }
            if (transform.childCount == 90)
            {
                Zpozisyon =  + 1.40f;
            }
            if (transform.childCount == 108)
            {
                Zpozisyon =  + 1.68f;
            }

            pozisyon = new Vector3(Xpozisyon, Ypozisyon, Zpozisyon);

            var obj = Instantiate(MoneyPrefab, transform.position,transform.rotation, transform);
            obj.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
            obj.transform.localPosition = pozisyon;
            Xpozisyon -= 0.6f;
            Counter++;
        }
    }
}
