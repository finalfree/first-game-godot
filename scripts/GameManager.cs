using Godot;    

public partial class GameManager : Node
{
    // public static GameManager Instance;
    //
    // public override void _EnterTree()
    // {
    //     Instance = this;
    // }

    public int Score => _score;
    private int _score = 0;

    Label _scoreLabel;
    public override void _Ready()
    {
        _scoreLabel = GetNode<Label>("%CanvasLayer/Label");
        _scoreLabel.Text = $"Score: {_score}";
    }

    public void AddScore()
    {
        _score++;
        _scoreLabel.Text = $"Score: {_score}";
        
    }
}
