using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Control;

namespace MyUI {
    public class StaminaController: MonoBehaviour {
        public PlayerStamina stamina;
        public Stamina[] points;

        public Stamina prototype;

        void Awake () {
            stamina.OnConsume += UpdateView;
            stamina.OnPowerup += UpdateView;

            points = new Stamina[12];
            for (int i=0; i<12; i++) {
                RectTransform n = Instantiate(prototype).GetComponent<RectTransform>();
                n.transform.SetParent(transform);
                n.anchoredPosition = new Vector2(i*50, 0);
                points[i] = n.GetComponent<Stamina>();
            }

            UpdateView();
        }

        public void UpdateView () {
            for (int i=0; i<points.Length; i++) {
                if (i >= stamina.max)
                    points[i].gameObject.SetActive(false);
                else {
                    points[i].gameObject.SetActive(true);
                    if (i < stamina.current) {
                        points[i].SetFull();
                    } else {
                        points[i].SetEmpty();
                    }
                }
            }
        }
    }
}
