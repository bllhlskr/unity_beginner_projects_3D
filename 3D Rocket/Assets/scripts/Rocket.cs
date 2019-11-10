using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidbody;
    AudioSource audio;
    [SerializeField]float rcsThrust = 100f;
    [SerializeField] float mainThrust = 10f;
    [SerializeField] float levelLoadDelay = 1f;
    int currentScene;
    int sceneCount;
    //Sounds
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip success;
    //Particles 
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] ParticleSystem successParticles;

    enum State {Alive,Dying,Transcending };
    State state = State.Alive;
    bool collisionAreEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audio = FindObjectOfType<AudioSource>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
        sceneCount = SceneManager.sceneCount;

    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Alive)
        {
            RespondToThrustInput();
            Rotate();
        }
        if (Debug.isDebugBuild)
        {
            RespondToDebugKeys();
        }
        
    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadNextLevel();
        }else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionAreEnabled = !collisionAreEnabled;
        }
    }

    private void RespondToThrustInput()
    {
      if (Input.GetKey(KeyCode.Space))
        {
            ApplyThrust();

        }
        else
        {
            audio.Stop();
            mainEngineParticles.Stop();
        }
    }

    private void ApplyThrust()
    {
        rigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audio.isPlaying)
        {
            audio.PlayOneShot(mainEngine);
        }
        mainEngineParticles.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(state != State.Alive || !collisionAreEnabled)
        {
            return;
        }


        switch (collision.gameObject.tag)
        {
            case "friendly": Debug.Log("youre ok");break;
            case "Finish":
                StartSuccess();
                break;
            case "deadly":
                StartDeath();
                break;
        }
    }

    private void StartDeath()
    {
        state = State.Dying;
        if (audio.isPlaying == true)
        {
            audio.Stop();
        }
        audio.PlayOneShot(deathSound);
        deathParticles.Play();
        Invoke("LoadFirstLevel", levelLoadDelay);
        
    }

    private void StartSuccess()
    {
        state = State.Transcending;
        Invoke("LoadNextLevel", levelLoadDelay);
        if (audio.isPlaying == true)
        {
            audio.Stop();
        }
        audio.PlayOneShot(success);
        successParticles.Play();
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void LoadNextLevel()
    {
       
        SceneManager.LoadScene(currentScene + 1);
        if(currentScene > sceneCount)
        {
            LoadFirstLevel();
        }
    }

    private void Rotate()
    {
        rigidbody.freezeRotation = true;
        
        if (Input.GetKey(KeyCode.A))
        {
            float rotationThisFrame = rcsThrust*Time.deltaTime;
            transform.Rotate(Vector3.forward * rotationThisFrame);

        }
        if (Input.GetKey(KeyCode.D))
        {
            float rotationThisFrame = rcsThrust * Time.deltaTime;
            transform.Rotate(-Vector3.forward * rotationThisFrame);

        }
        
        rigidbody.freezeRotation = false;
    }
}
