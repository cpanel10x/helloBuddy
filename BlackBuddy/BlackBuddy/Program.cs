using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using SharpDX;
namespace BlackBuddy
{

internal class Program
{

    public static Menu Menu;
    public static AIHeroClient player = Player.Instance;
    private static readonly Vector3 PurpleSpawn = new Vector3(14286f, 14382f, 172f);
    private static readonly Vector3 BlueSpawn = new Vector3(416f, 468f, 182f);

        private static void Main(string[] args)
        {
            try
            {
                Loading.OnLoadingComplete += Loading_OnLoadingComplete;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }


        }

        public static void Loading_OnLoadingComplete(EventArgs arg)
        {
            try
            {
                Game.OnUpdate += OnUpdate;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e);
            }
        }

        private static void Game_OnStart(EventArgs args)
    {

        Menu = MainMenu.AddMenu("BlackBuddy", "BlackBuddy");

        Menu.AddGroupLabel("Black Feeder EloBuddy");
        Menu.AddLabel("from woody with love <3");
        Menu.AddSeparator();
        Menu.AddLabel("V1.0");
        Menu.AddSeparator();
        Menu.AddLabel("clone from BlackFeeder");
            /*BlackBud = Menu.AddSubMenu("BlackBud", "BlackBud");
            BlackBud.AddGroupLabel("BlackBud Feeder");
            BlackBud.AddLabel("Mastery spam requires level 4+ on the champion to use!");
            BlackBud.AddLabel("Spamming emotes will reduce orbwalker efficency!");
            var EmoteSpamList = Emote.Add("Emote Spamming", new Slider("EmoteList", 0, 0, 3));
            EmoteSpamList.OnValueChange += delegate
            {
                EmoteSpamList.DisplayName = "Spamming " + new[] { "Laugh", "Taunt", "Joke", "Mastery" }
                [EmoteSpamList.CurrentValue];
            };
            Emote.Add("EmotePressHotkey", new KeyBind("Press To Spam", false, KeyBind.BindTypes.HoldActive, 'T'));
            Emote.Add("EmoteToggleHotkey", new KeyBind("Toggle To Spam", false, KeyBind.BindTypes.PressToggle, 'L'));
            */
            Game.OnUpdate += OnUpdate;
    }

    public static void OnUpdate(EventArgs args)
    {
            if (player.Team == GameObjectTeam.Order)
            {
                Player.IssueOrder(GameObjectOrder.MoveTo, PurpleSpawn);
            }
            else
            {
                Player.IssueOrder(GameObjectOrder.MoveTo, BlueSpawn);
            }
        }

}
}