
public class Rules {
    public string[] possible;
    public int right;
    public Rules(string[] _possible, int _right){
        possible = _possible;
        right = _right;
    }

    public string IsWon(int answer){
        if(right==answer)
            return "Draw";

        int half = (possible.Length - 1) / 2;
        int win = right + half;
        
        if(win>=possible.Length){
            win -= possible.Length;
            if ((answer > right && answer < possible.Length) || answer <= win)
                return "You won!";

        }else if (answer>right && answer<=win)
            return "You won!";

        return "You lost!";
    }
}