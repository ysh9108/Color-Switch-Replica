using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForece = 10f;

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPink;

    public StageController stageController;

    void Start()
    {
        // this.transform.position = new Vector3(0, 0, 0);
        SetRandomColor();
        stageController.InitializeGame();
        stageController.StartStage();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForece;
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(col.gameObject);
            return;
        }

        if (col.tag == "StageChanger")
        {
            stageController.StageClear();
            return;
        }

        if (col.tag != currentColor)
        {
            Debug.Log("GAME OVER!" + col.transform.position + " | " + col + " | Player : " + this.transform.position);
            SceneController.ReloadScene();
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;

            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;

            case 2:
                currentColor = "Pink";
                sr.color = colorPink;
                break;

            case 3:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;
        }
    }

}
