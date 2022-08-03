using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    Vector3 _initialPosition;

    private bool _birdWadLaunched = false;

    private float _timeSittingAround;

    [SerializeField]
    private float _launchPower = 0;

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        Vector3 _currentPos = new Vector3(transform.position.x, transform.position.y);
        GetComponent<LineRenderer>().SetPosition(0, _currentPos);

        Vector3 _initialPos = new Vector3(_initialPosition.x, _initialPosition.y);
        GetComponent<LineRenderer>().SetPosition(1, _initialPos);
        

        if (_birdWadLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }

        if (transform.position.y > 10 || transform.position.y < -10 || transform.position.x > 15 || transform.position.x < -15 || _timeSittingAround > 3)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;

        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToIntialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToIntialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;

        _birdWadLaunched = true;

        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag()
    {        
        Vector3 newPosition =Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }

}
