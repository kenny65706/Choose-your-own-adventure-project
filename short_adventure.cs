using System;

namespace Short_Adventure
{
	class program
	{
	
	   static int RenderScreen(string output)
        {
            Console.Clear();
            int line_length = 80;
            int desired_length = line_length - 5;

            Console.WriteLine("".PadRight(line_length, '='));
            while (output.Length > desired_length)
            {
                Console.WriteLine("| " + output.Substring(0, desired_length).PadRight(line_length - 3) + "|");
                output = output.Remove(0, desired_length);
            }
            Console.WriteLine("| " + output.PadRight(line_length - 3) + "|");
            Console.WriteLine("".PadRight(line_length, '='));
            Console.ReadLine();
            return output.Length;
        }
	
	static void Main(string[] args)
		{
			//creating a choose your own adventure
			//ToLower fixed input issue with user providing upper case input
			//Trim fixed input issue where user provided spaces for input that needed to be checked
			//bool fixed problem of tracking "dead" outside the while block where I had loop that caused death. 
			//Console.Readkey allowed for a pause for user to read and continue when ready. 
			//Console.Clear allowed for ease of reading, avoiding massive wall of text
			//Edit grammar and mispelling on multiple dialogue.
			
			int exhaustion = 2;
			bool play_again = true;
			while (play_again)
			{
				//setting the bool in the while loop fixed issue where play again auto killed user when choosing path west or east
				bool dead =false;
				Console.Clear();
				RenderScreen("Dangerous Delivery"); 
				RenderScreen("Day 1 Morning");
				RenderScreen("You walk into the guild hall. You are broke and looking for work. \nAs you approach the board the guild attendent smiles and greets you\n\"Hello and welcome to the guild hall. What is your name?\"");
				string your_name = Console.ReadLine();
				Console.Write(string.Format("\"Well met {0} it is nice to meet you. What can I do to assist you today\"\n\"Looking for work.\"You explain.\"\n\"Perfect! We have a job that requires you to deliver this medicine to the elder of a nearby village. Do you want to take on this task?\"(please type 'yes' or'no'): ", your_name));
				String accept_quest_input = Console.ReadLine().ToLower().Trim();
				while(accept_quest_input != "yes" && accept_quest_input != "no")
				{
					RenderScreen("I'm sorry"+" "+your_name+" , I don't speak gibberling. Can you plainly say yes or no?: ");
					accept_quest_input = Console.ReadLine().ToLower().Trim();
				}
				if (accept_quest_input == "yes")
				{
					RenderScreen(string.Format("Fantastic! Here is the medicine, it is only good for a few days, so please hurry. Take the southern pass and make sure to stay to the left at all costs, good luck, {0}.\nPress any key to leave", your_name));
					Console.ReadKey();
					Console.Clear();
					RenderScreen("You leave the guild hall and proceed to head south. You know the way to the nearby village the guild attendant spoke about. It's just over a days travel away.\nAfter an hour you check your gear.\nSword? Check!\nFood? Uh,only one days worth of food.\nYou curse yourself for spending all that money on booze the night before. You have a job to do and this should be enough to get you there.\nPress any key to continue.");
					Console.ReadKey();
					RenderScreen("Day 1 Afternoon");
					RenderScreen("You continue south towards the mountain until you get to the southern pass. The land is barren, lifeless. The pass goes through a crevice in thhe mountain about two men wide if they were to stand shoulder to shoulder.");
					RenderScreen("As you start to head into the crevice, you here a growl behind you. You turn around reflexively to see a grey wolf baring teeth ");
					RenderScreen("The wolf takes a step back. You take this time to further inspect the beast. It looks thin, most likely from trying to survive in this meager enviroment. You could probably scare it off with out causing it harm. You could also feed it your only days worth of rations. You won't starve but it will make the trip less enjoyable.");
					RenderScreen("Do you feed the wolf or attack? Please type 'attack' or 'feed'");
					string wolf_answer = Console.ReadLine().ToLower().Trim();
				
					if (wolf_answer == "feed")
					{
						Console.Clear();
						RenderScreen("You take out your rations amd offer it to the wolf. The wolf eyes your warily, then quickly takes the morsel hungrily.");
						RenderScreen("You move towards the crevice, confident that the wolf is content with his meal.");
						RenderScreen("Proceeding down the path, you glance back and see that the wolf is following you.\n\"what do you want\" you ask");
						RenderScreen("The wolf makes a happy grunting chuffing sound. \n\"Well if you want to come that is fine, but what should I call you?\"");
						RenderScreen("What do you call the wolf?: ");
						string wolf_name = Console.ReadLine();
						RenderScreen(string.Format("\"{0}, thats a good name, come on lets go.\"\nPress any key to continue.", wolf_name));
						Console.ReadKey();
						
						
						//this choice will have a loop if the user chooses the "right: path and breaks loop if the user chooses "left" path
						for ( int i = exhaustion; i >=0; i--)
						{
							Console.Clear();
							RenderScreen(string.Format(" You and {0} continue down the path. You come to a intersection, a path going west and a path going east",wolf_name));
							RenderScreen("You try to remember what the guild attendent had told you. west or east?");
							string path_choice =  Console.ReadLine().ToLower().Trim();
							while (path_choice != "east" && path_choice != "west")
							{
								RenderScreen("The only direction to move forward is to go is east or west.");
								path_choice =  Console.ReadLine().ToLower().Trim();
							}
							if (path_choice == "east"){break;}
							if (i == 0) {dead = true; break;}
							if (i == 1){RenderScreen("You decide to go along the west path again. This time taking your time navigating the slopes. more hours pass but you reach the top. You over look the pass and it seems like the only way forward is back down the slope you fell before. You navigate it carefully to be back in front of the original path.\nPress any key to continue"); Console.ReadKey();}
							else 
							{
							RenderScreen(" You choose the west path. It is  rocky and treacherous. Hours have passed as you finally reach the top of the path you stumble, sliding down a slope. Battered and bruised you pick yourself up. You recognize that you are back on the original path before the intersection.\nPress any key to continue.");
							Console.ReadKey();
							}
							
						}
						if (dead == true)
						{
							RenderScreen("Thinking third time is the charm and that you may find some sort of secret trail, you head down the west path again. Nothing new appears as you climb and climb. As you reach the top you collapse from exhaustion. Unable to move forward you think of the people that will die due to your failure. Then everything fades to black");
							RenderScreen("Press any key to die");
							Console.ReadKey();
						}
						//bug when choosing east the first time triggering west
						else 
						{
							Console.Clear();
							RenderScreen( "You head down the east path. It seems to be correct trail, well traveled and free of debris.");
							RenderScreen(string.Format("As you and {0} travel down the path you notice a clearing up ahead. \nAs you enter the clearing, you hear a click to your right.\nYou turn to face the sound and see a figure in a grey cloak, their face shrouded within the cowl.\nThe stranger is about thirty feet way and has a crossbow at the ready.", wolf_name));
							RenderScreen(string.Format("The stranger speaks in a gruff male voice\n\"{0} I presume? It sure would be a shame if you died today and the package you carry doesn't reach the village. I think the master would be pleased with me ending your heroic life.\"\nThe assassin begins to bring the crossbow to his shoulder to fire.", your_name));
							RenderScreen(string.Format("You could try to draw your blade and cut the man down before he could get a shot off, it is quite the distance to cover before he shoots. \nYou could also try to command {0} to attack and distract the assassin, giving you time to cover the distance. Will the wolf listen to your command?", wolf_name));
							RenderScreen("Do you attack alone or together? Please type 'alone' or 'together'");
							string attack_answer = Console.ReadLine().ToLower().Trim();
							while (attack_answer != "alone" && attack_answer != "together")
								{
								RenderScreen("You don't see any other way to survive. Please type 'alone' or 'together'");
								attack_answer = Console.ReadLine().ToLower().Trim();
								}
							if(attack_answer == "together")
							{
								Console.Clear();
								RenderScreen(string.Format("You yell\"{0}!\"\nThe assassin pauses for a moment\"Who or what is a {0}\"\nAs if on cue, {0} Leaps at the stranger, grasping his arm in their maw.\n\"What the heck!\"\nYou take this oppurtunity to dash forward, drawing your sword to strike a blow to the assassin's chest.",wolf_name));
								RenderScreen("The assassin falls to the ground dead.\n\"You did great "+wolf_name+" !\" You say");
								RenderScreen("with nothing else in your way you go to leave the clearing and continue onward to the village. \nPress any key to continue");
								Console.ReadKey();
								Console.Clear();
								RenderScreen("Day 1 Evening \nYou continue down the trail for several hours. You finally exit out on the other side of the mountain,seeing the village not that far away");
								RenderScreen("As you approach the dusty village, a man in a white robe comes to meet you.\n\"Well met adventurer.\" He says.\"I am the village elder, I had sent a runner to ruquest medicine from the guild. Might you be who they sent?\" ");
								RenderScreen("You nod as you reach to your pouch to pull the medicine you had been carrying.\nThe Elder's eyes grow wide as he takes the package\"Oh thank the Gods! Bless you...Bless you. I've been getting on in my years and well i got a young wife. The guild has your pay, and good day to you\"");
								RenderScreen("The elder heads off, seemingly with an extra pep in his step.");
								RenderScreen("All that trouble to dick pills...Well you deed is done and you should stop by the inn to get food before heading back to the guild to collect your pay.\nYou wonder what was the assassin you encountered earlier rambling about. A master? Who is that?\n\n\nThat is for another tale"); 
							
							}
							if(attack_answer == "alone")
							{
								Console.Clear();
								RenderScreen(string.Format("You rush forward to attack the assassin.\n The assassin is quicker, loosing a bolt from his weapon, hitting you square in the chest. \nYou fall to your knees clutching your chest. As the the world fades to black you hear the assassin approach.\n\"You had it coming {0}, no one gets in the way of the master and his family.\" The assassin growls ", your_name));
								RenderScreen("You hear nothing else ever again");
							}
							
							
						}
						
					}
					if (wolf_answer == "attack") 
					{
					RenderScreen("You reach for your sword. The wolf realizing your intent, lunges at your throat. The hungry beast connects and brings you to the ground.\nAs you lay there dying, you ponder how it could end this way. \nThen everything is black.");
					}
				}	
				if (accept_quest_input == "no")
				RenderScreen("The guild attendant frowns\n\"A pity...well there are not other jobs at this time. I see another adventurer had just come in. If there is nothing else I can help you with I bid you good day\"\nYou leave the guild hall not sure what you are going to do with your day. Guess there is the local pub.\n\n\n");
				string play_again_input = "";
                Console.Write("Would you like to play again [y/n]: ");
                play_again_input = Console.ReadLine().ToLower().Trim();
                while (play_again_input != "y" && play_again_input != "n")
                {
                    Console.Write("Invalid input \nPlease type \"y\" or \"n\": ");
                    play_again_input = Console.ReadLine();
                }

                if (play_again_input == "n") { play_again = false; }

			}
		}
		
	}	
}