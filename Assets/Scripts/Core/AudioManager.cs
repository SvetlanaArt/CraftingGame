using UnityEngine;

namespace CraftingModule.Core
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Craft")]
        [SerializeField] AudioClip craftSuccessSound;
        [SerializeField] AudioClip craftFaildSound;
        [SerializeField][Range(0f, 1f)] float craftVolume = 1f;

        [Header("Player")]
        [SerializeField] AudioClip pickUpSound;
        [SerializeField] AudioClip dropSound;
        [SerializeField][Range(0f, 1f)] float playerVolume = 1f;

        static AudioManager instance;

        public void Awake()
        {
            CheckSingleton();
        }

        void CheckSingleton()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }

        public void PlayCraftSuccessSound()
        {
            PlaySound(craftSuccessSound, craftVolume);
        }

        public void PlayCraftFaildSound()
        {
            PlaySound(craftFaildSound, craftVolume);
        }

        public void PlayPickUpSound()
        {
            PlaySound(pickUpSound, playerVolume);
        }

        public void PlayDropSound()
        {
            PlaySound(dropSound, playerVolume);
        }

        void PlaySound(AudioClip sound, float volume)
        {
            if (sound != null)
            {
                AudioSource.PlayClipAtPoint(sound,
                                            Camera.main.transform.position,
                                            volume);
            }
        }
    }

}

