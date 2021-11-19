using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Nestre.Progression;
using Nestre.UI;

namespace Nestre.Game1
{
    public class ShapeHandler : MonoBehaviour
    {
        [SerializeField] GameObject[] shapePrefabs;
        [SerializeField] Transform spawnParent;
        [SerializeField] Button[] buttons;
        [SerializeField] TimerBar timerBar;
        [SerializeField] Validator validator;
        [SerializeField] GameObject helpText;

        Progressor progressor;

        List<GameObject> activeShapes = new List<GameObject>();

        private void Awake()
        {
            progressor = GetComponent<Progressor>();
            progressor.onDifficultyIncreased += () => { StartCoroutine(EndTurn()); };
        }

        private IEnumerator StartGameCoroutine()
        {
            yield return new WaitForSeconds(1f);
            SpawnNewShape();
            yield return new WaitForSeconds(2f);
            StartCoroutine(EndTurn());
            timerBar.SetActiveState(true);
            helpText.SetActive(true);
        }

        public void StartGame()
        {
            StartCoroutine(StartGameCoroutine());
        }

        IEnumerator EndTurn()
        {
            ActivateButtons(false);
            Animator anim = activeShapes[0].GetComponent<Animator>();
            AudioSource source = activeShapes[0].GetComponent<AudioSource>();
            anim.SetTrigger("SlideOut");
            source.Play();
            yield return new WaitForSeconds(1f);
            SpawnNewShape();
            ActivateButtons(true);
        }

        void SpawnNewShape()
        {
            //spawn the next shape
            GameObject nextShape = Instantiate(shapePrefabs[UnityEngine.Random.Range(0, shapePrefabs.Length)],
                spawnParent.transform);

            //add it to the list
            activeShapes.Insert(0, nextShape);

            //clean up the list
            CleanActiveShapes();
        }

        void CleanActiveShapes()
        {
            if(activeShapes.Count > progressor.GetMaxDifficulty() + 2)
            {
                GameObject deadShape = activeShapes[activeShapes.Count - 1];
                activeShapes.Remove(deadShape);
                Destroy(deadShape);
            }
        }

        //This method is called by the "Same"/"Different" buttons
        public void CheckCurrentShape(bool check)
        {
            int level = progressor.GetCurrentDifficulty();
            bool wasCorrect = activeShapes[0].CompareTag(activeShapes[level + 1].tag) == check;
            
            validator.CheckValidation(wasCorrect);

            bool finishedLevel = false;
            progressor.IterateTurns(wasCorrect, out finishedLevel);

            if(!finishedLevel)
            StartCoroutine(EndTurn());
        }

        private void ActivateButtons(bool isInteractable)
        {
            foreach (Button button in buttons)
            {
                button.interactable = isInteractable;
            }
        }

        private void OnDisable()
        {
            progressor.onDifficultyIncreased -= () => { StartCoroutine(EndTurn()); };
        }
    }
}
