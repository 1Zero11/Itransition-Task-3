using ConsoleTables;

/// <summary>
/// В таблице значения You won!, Draw и You lost! так как их возвращает класс Rulles.
/// Опять же, если очень надо, можно переделать...
/// </summary>
public class TableBuilder{
    string[] possible;
    public TableBuilder(string[] _possible){
        possible = _possible;
    }

    public ConsoleTable BuildTable(){
        Rules rules = new Rules(possible, 0);

        var table = new ConsoleTable(new string[]{""}.Concat(possible).ToArray());
        for (int i = 0; i < possible.Length; i++)
        {
            rules.right = i;
            List<string> answers = new List<string>();
            answers.Add(possible[i]);
            for (int j = 0; j< possible.Length; j++){
                answers.Add(rules.IsWon(j));
            }

            table.AddRow(answers.ToArray());
        }

        return table;
    }
}