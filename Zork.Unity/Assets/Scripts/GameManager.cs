using UnityEngine;
using Zork;
using Zork.Common;
using Newtonsoft.Json;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI CurrentLocationText;

    [SerializeField]
    private TextMeshProUGUI MovesText;

    [SerializeField]
    private TextMeshProUGUI ScoreText;

    [SerializeField]
    private UnityInputService InputService;
    
    [SerializeField]
    private UnityOutputService OutputService;

    [SerializeField]
    private string ZorkGameFileAsset = "Zork";

    void Awake()
    {
        TextAsset gameJsonAsset = Resources.Load<TextAsset>(ZorkGameFileAsset);
        _game = JsonConvert.DeserializeObject<Game>(gameJsonAsset.text);
        _game.Player.LocationChanged += Player_LocationChanged;
        _game.Player.MovesChanged += Player_MovesChanged;
        _game.Player.ScoreChanged += Player_ScoreChanged;

        _game.Start(InputService, OutputService);
    }

    void Start()
    {
        CurrentLocationText.text = _game.Player.Location.Name;
    }

    private void Player_LocationChanged(object sender, Room newLocation)
    {
        if (_game.Player.Location != _previousLocation)
        {
            CurrentLocationText.text = newLocation.ToString();

            Game.Look(_game);
            _previousLocation = _game.Player.Location;
        }
    }

    private void Player_MovesChanged(object sender, int moves)
    {
        MovesText.text = $"Moves: {moves.ToString()}";
    }

    private void Player_ScoreChanged(object sender, int score)
    {
        ScoreText.text = $"Score: {score.ToString()}";
    }

    private Game _game;
    private Room _previousLocation;
}
