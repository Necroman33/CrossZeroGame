using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cross_zero_game
{
    class Logic
    {
        CrossZeroEntities context = new CrossZeroEntities();
        private bool check_turn(char[,] arr, char user, char ii, char first)
        {
            int user_symbols = 0;
            int ii_symbols = 0;
            for (var x = 0; x < 3; x++)
            {
                for (var y = 0; y < 3; y++)
                {
                    if(arr[x,y] == user)
                    {
                        user_symbols++;
                    }
                    else if(arr[x,y] == ii)
                    {
                        ii_symbols++;
                    }
                }
            }
            if (user_symbols > ii_symbols && first =='u')
            {
                return true;
            }
            else
            {
                if (user_symbols < ii_symbols && first == 'u')
                {
                    return false;
                }
                else
                {
                    if (user_symbols == ii_symbols && first == 'i')
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public string turn(char[,] arr, char user, char ii, char first)
        {
            string result = "";
            if(check_turn(arr, user, ii, first))
            {
                result+=important_turn(arr, ii, ii);
                if (result != "")
                {
                    int x = Convert.ToInt32(result.Substring(4, 1));
                    int y = Convert.ToInt32(result.Substring(6, 1));
                    arr[x - 1, y - 1] = ii;
                }
            }
            if (check_turn(arr, user, ii, first))
            {
                result+=important_turn(arr, user, ii);
                if (result != "")
                {
                    int x = Convert.ToInt32(result.Substring(4, 1));
                    int y = Convert.ToInt32(result.Substring(6, 1));
                    arr[x - 1, y - 1] = ii;
                }
            }
            if (check_turn(arr, user, ii, first))
            {
                result += logic_turn(arr, user, ii, first);
            }
            return result;
        }

        private string important_turn(char[,] arr, char line_symbol, char ii)
        {
            char x = line_symbol;
            if ((((arr[0,0] == x) && (arr[1,0] == x)) || ((arr[0,2] == x) && (arr[1,1] == x)) || ((arr[2,1] == x) && (arr[2,2] == x))) && (arr[2,0] == '0'))
            {
                return "cell3_1";
            }
            else
            {
                if ((((arr[0,1] == x) && (arr[1,1] == x)) || ((arr[2,0] == x) && (arr[2,2] == x))) && (arr[2,1] == '0'))
                { return "cell3_2"; }
                else
                {
                    if ((((arr[0,0] == x) && (arr[1,1] == x)) || ((arr[0,2] == x) && (arr[1,2] == x)) || ((arr[2,0] == x) && (arr[2,1] == x))) && (arr[2,2] == '0'))
                    { return "cell3_3"; }
                    else
                    {
                        if ((((arr[1,0] == x) && (arr[1,1] == x)) || ((arr[0,2] == x) && (arr[2,2] == x))) && (arr[1,2] == '0'))
                        { return "cell2_3"; }
                        else
                        {
                            if ((((arr[0,0] == x) && (arr[0,1] == x)) || ((arr[1,1] == x) && (arr[2,0] == x)) || ((arr[1,2] == x) && (arr[2,2] == x))) && (arr[0,2] == '0'))
                            { return "cell1_3"; }
                            else
                            {
                                if ((((arr[0,0] == x) && (arr[0,2] == x)) || ((arr[1,1] == x) && (arr[2,1] == x))) && (arr[0,1] == '0'))
                                { return "cell1_2"; }
                                else
                                {
                                    if ((((arr[0,1] == x) && (arr[0,2] == x)) || ((arr[1,0] == x) && (arr[2,0] == x)) || ((arr[1,1] == x) && (arr[2,2] == x))) && (arr[0,0] == '0'))
                                    { return "cell1_1"; }
                                    else
                                    {
                                        if ((((arr[0,0] == x) && (arr[2,0] == x)) || ((arr[1,1] == x) && (arr[1,2] == x))) && (arr[1,0] == '0'))
                                        { return "cell2_1"; }
                                        else
                                        {
                                            if ((((arr[0,0] == x) && (arr[2,2] == x)) || ((arr[2,0] == x) && (arr[0,2] == x)) || ((arr[0,1] == x) && (arr[2,1] == x)) || ((arr[1,0] == x) && (arr[1,2] == x))) && (arr[1,1] == '0'))
                                            { return "cell2_2"; }
                                            else
                                            {
                                                return "";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private string logic_turn(char[,] arr, char user, char ii, char first)
        {
            int fist_sybols = 0;
            for (var x = 0; x < 3; x++)
            {
                for (var y = 0; y < 3; y++)
                {
                    if (first =='u')
                    {
                        if (arr[x,y] == user)
                        {
                            fist_sybols++;
                        }
                    }
                    else if (first =='i')
                    {
                        if (arr[x, y] == ii)
                        {
                            fist_sybols++;
                        }
                    }
                }
            }
            switch (fist_sybols)
            {
                case 1:
                    if (arr[1,1] == '0')
                    {
                        return "cell2_2";
                    }
                    else
                    {
                        if (arr[2, 0] == '0')
                        {
                            return "cell3_1";
                        }
                        else
                        {
                            return "cell1_3";
                        }
                    }
                case 2:
                    if ((arr[1, 1] == ii) && (((arr[0, 1] == user) && (arr[2, 2] == user)) || ((arr[0, 1] == user) && (arr[2, 0] == user))) && (arr[1, 2] == '0'))
                    {
                        return "cell2_3";
                    }
                    else
                    {
                        if ((arr[1, 1] == ii) && ((arr[0, 0] == user) || (arr[2, 2] == user) || (arr[0, 2] == user) || (arr[2, 0] == user)) && (arr[2, 1] == '0'))
                        {
                            return "cell3_2";
                        }
                        else
                        {
                            if ((arr[1, 1] == ii) && (arr[1, 0] == user) && (arr[2, 0] == '0'))
                            {
                                return "cell3_1";
                            }
                            else
                            {
                                if ((arr[1, 1] == ii) && (arr[1, 2] == user) && (arr[0, 2] == '0'))
                                {
                                    return "cell1_3";
                                }
                                else
                                {
                                    if ((arr[1, 1] == ii) && (arr[2, 1] == user) && (arr[2, 2] == '0'))
                                    {
                                        return "cell3_3";
                                    }
                                    else
                                    {
                                        if ((arr[0, 1] == ii) && (arr[1, 0] == user) && (arr[0, 0] == '0'))
                                        {
                                            return "cell1_1";
                                        }
                                        else
                                        {
                                            if ((arr[2, 0] == ii) && (arr[1, 1] == user) && (arr[0, 0] == '0'))
                                            {
                                                return "cell1_1";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 3:
                    if ((arr[1,1] == ii) && ((arr[1,0] == user) && (arr[0,1] == user)) && (arr[0,0] == '0'))
                    {
                        return "cell1_1";
                    }
                    else
                    {
                        if ((arr[1,1] == ii) && ((arr[1,0] == user) && (arr[2,1] == user)) && (arr[2,0] == '0'))
                        {
                            return "cell3_1";
                        }
                        else
                        {
                            if ((arr[2,1] == ii) && ((arr[1,2] == user) && (arr[0,1] == user)) && (arr[2,2] == '0'))
                            {
                                return "cell3_3";
                            }
                            else
                            {
                                if ((arr[1,1] == ii) && ((arr[1,2] == user) && (arr[0,1] == user)) && (arr[0,2] == '0'))
                                {
                                    return "cell1_3";
                                }
                                else
                                {
                                    for (var y = 0; y < 3; y++)
                                    {
                                        for (var x = 0; x < 3; x++)
                                        {
                                            if (arr[y,x] != user && arr[y, x] != ii)
                                            {
                                                return $"cell{y+1}_{x+1}";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 4: 
                    for (var y = 0; y < 3; y++)
                    {
                        for (var x = 0; x < 3; x++)
                        {
                            if (arr[y, x] != user && arr[y, x] != ii)
                            {
                                return $"cell{y+1}_{x+1}";
                            }
                        }
                    }
                    break;
                case 5:
                    for (var y = 0; y < 3; y++)
                    {
                        for (var x = 0; x < 3; x++)
                        {
                            if (first == 'u')
                            {
                                if (arr[y, x] != user)
                                {
                                    return $"cell{y + 1}_{x + 1}";
                                }
                            }
                            else
                            {
                                if (arr[y, x] != user && arr[y, x] != ii)
                                {
                                    return $"cell{y + 1}_{x + 1}";
                                }
                            }
                        }
                    }
                    break;

            }
            return "";
        }

        private bool combo(char[,] arr, char x)
        {
            if (((arr[0,0] == x) && (arr[1,0] == x) && (arr[2,0] == x)) || ((arr[0,1] == x) && (arr[1,1] == x) && (arr[2,1] == x)) || 
                ((arr[0,2] == x) && (arr[1,2] == x) && (arr[2,2] == x)) || ((arr[0,0] == x) && (arr[0,1] == x) && (arr[0,2] == x)) || 
                ((arr[1,0] == x) && (arr[1,1] == x) && (arr[1,2] == x)) || ((arr[2,0] == x) && (arr[2,1] == x) && (arr[2,2] == x)) || 
                ((arr[0,0] == x) && (arr[1,1] == x) && (arr[2,2] == x)) || ((arr[2,0] == x) && (arr[1,1] == x) && (arr[0,2] == x)))
            {
                return true;
            }
            else
            {
                return false;
            }
    }
        public string result(char[,] arr, char user, char ii)
        {
            if (combo(arr, user))
            {
                return "Win";
            }
            else
            {
                if (combo(arr, ii))
                {
                    return "Lose";
                }
                else
                {
                    int check = 0;
                    for (var y = 0; y < 3; y++)
                    {
                        for (var x = 0; x < 3; x++)
                        {
                            if (arr[y, x] != user && arr[y, x] != ii)
                            {
                                check++;
                            }
                        }
                    }
                    if (check == 0)
                    {
                        return "Draw";
                    }
                    else
                    {
                        return "";
                    }
                }
            }
        }

        public void addPoint(string user, string pointType)
        {
            var scores = context.Scores.ToList();
            var user_scores = scores.Where(u => u.Username == user).FirstOrDefault();
            switch (pointType)
            {
                case "Win":
                    user_scores.Wins++;
                    break;
                case "Lose":
                    user_scores.Defeats++;
                    break;
                case "Draw":
                    user_scores.Draws++;
                    break;
            }
            context.SaveChanges();
        }
    }
}
