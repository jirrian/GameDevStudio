using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class textWorld : MonoBehaviour {
	int currRoom;	// 1 == large hallway
					// 2 == small room
	string currObjt;	// object currently interacting with
	int currBranch;	// keep track of 2nd tier of choices in object
	int currBranch2; // 3rd tier in object
	bool isLarge;	// if player is large
	bool lKey;	// if player has large key
	bool sKey;	// if player has small key
	bool gotPizza;	// if player has pizza in pocket
	bool gotBTea;	// if player has bubble tea in pocket
	bool first;	// true if player has not transformed yet
	string textBuffer;
	int count;	// keep count of times key pressed in room 2 in case player is at dead end

	// Use this for initialization
	void Start () {
		// default values for start of game
		currRoom = 1;
		currObjt = "null";
		currBranch = 0;
		currBranch2 = 0;
		isLarge = true;
		lKey = false;
		sKey = false;
		gotPizza = false;
		gotBTea = false;
		first = true;
		textBuffer = "";
		int count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		textBuffer = "";

		if(currRoom == 1){
			if(currObjt == "null"){	// general menu for room
				textBuffer += getRoomDescrip();	// room description

				textBuffer += "\n[Q] Examine door at end of hallway";
				textBuffer += "\n[W] Examine small door";
				if(isLarge && !gotBTea){	// can only examine bubble tea if large
					textBuffer += "\n[E] Examine bubble tea";
				}else if(!isLarge && !gotPizza){	// can only examine pizza if small
					textBuffer += "\n[E] Examine pizza";
				}
				textBuffer += "\n[R] Examine table";
				if(gotBTea)
					textBuffer += "\n[T] Take out bubble tea";
				if(gotPizza)
					textBuffer += "\n[Y] Take out pizza";

				// read input and change object interacting with
				if(Input.GetKeyDown(KeyCode.Q)){
					currObjt = "lDoor";
				}else if(Input.GetKeyDown(KeyCode.W)){
					currObjt = "sDoor";
				}else if(Input.GetKeyDown(KeyCode.E)){
					if(isLarge)
						currObjt = "bubbleT";
					else
						currObjt = "pizza";
				}else if(Input.GetKeyDown(KeyCode.R)){
					currObjt = "table";
				}else if(gotBTea && Input.GetKeyDown(KeyCode.T)){	// if food items are in pocket
					currObjt = "bubbleT";
				}else if(gotPizza && Input.GetKeyDown(KeyCode.Y)){
					currObjt = "pizza";
				}
			}
			else if(currObjt == "lDoor"){
				textBuffer += "You examine the door at end of hallway.";
				textBuffer += "\n[Q] Open door";
				textBuffer += "\n[W] Look at something else";

				if(Input.GetKeyDown(KeyCode.Q)){
						if(!isLarge){	// need to be big
							currBranch = 1;
						}
						else if (sKey && !lKey){	// need lKey
							currBranch = 2;
						}
						else if(!lKey){	// no lKey but has sKey
							currBranch = 3;
						}
						else{	// area ends
							currBranch = 4;
						}

				}else if(Input.GetKeyDown(KeyCode.W)){	// go back to main menu of area
					currObjt = "null";
				}

				// display messages
				if(currBranch == 1){
						textBuffer += "\nYou are too small to reach the door knob. ";

						if(Input.GetKeyDown(KeyCode.W)){
							currBranch = 0;
							currObjt = "null";
						}
				}else if(currBranch == 2){
					textBuffer += "\nYour key doesn't fit. ";

					if(Input.GetKeyDown(KeyCode.W)){
						currBranch = 0;
						currObjt = "null";
					}
				}else if(currBranch == 3){
						textBuffer += "\nIt's locked. ";

						if(Input.GetKeyDown(KeyCode.W)){
							currBranch = 0;
							currObjt = "null";
						}
				}else if(currBranch == 4){	// end of game
					textBuffer = "You unlock the door and push it open. You are flooded by bright light and the smell of grass...\nSeems like you fell asleep reading at the park again. Screw Carroll, it's time to get some 99 cent pizza!\n\nTHE END";
				}
			}else if(currObjt == "sDoor"){
				textBuffer += "You examine the small door.";
				textBuffer += "\n[Q] Open door";
				textBuffer += "\n[W] Look at something else";

				if(Input.GetKeyDown(KeyCode.Q)){
						if(isLarge){	// need to be small
							currBranch = 1;
						}
						else if (!sKey){	// need lKey
							currBranch = 2;
						}
						else{	// go to room 2
							currRoom = 2;
							currObjt = "null";	// reset for next room
							currBranch = 0;
						}

				}else if(Input.GetKeyDown(KeyCode.W)){	// go back to main menu of area
					currObjt = "null";
				}

				// display messages
				if(currBranch == 1){
						textBuffer += "\nYou are too large to fit through the door. ";

						if(Input.GetKeyDown(KeyCode.W)){
							currBranch = 0;
							currObjt = "null";
						}
				}else if(currBranch == 2){
						textBuffer += "\nIt's locked. ";

						if(Input.GetKeyDown(KeyCode.W)){
							currBranch = 0;
							currObjt = "null";
						}
				}

			}else if(currObjt == "bubbleT"){
				bubbleTea();	// call helper function

			}else if(currObjt == "pizza"){
				pizza();	// call helper function

			}else if(currObjt == "table"){
				textBuffer += "You examine the table.";
				if(isLarge && !sKey)
					textBuffer += "\n[Q] Look at surface.";
				if(!isLarge && !sKey)
					textBuffer += "\n[Q] Look underneath tabletop.";
				if(sKey)
					textBuffer += "Nothing much to see.";
				textBuffer += "\n[W] Look at something else";

				if(Input.GetKeyDown(KeyCode.Q)){
						if(isLarge){	// get small key
							currBranch = 1;
						}
						else{	// discover small key
							currBranch = 2;
						}

				}else if(Input.GetKeyDown(KeyCode.W)){	// go back to main menu of area
					currObjt = "null";
				}

				// display messages
				if(currBranch == 1){
						textBuffer += "\nThe table top is made of a dark wood that was once polished. A thin layer of dust covers everything. You place your hand around the edge of the table and feel something cold.\nYou found a small brass key taped to the underside of the table!\nYou now have a key.";

						if(Input.GetKeyDown(KeyCode.W)){
							sKey = true;
							currBranch = 0;
							currObjt = "null";
						}
				}else if(currBranch == 2){
						textBuffer += "\nYou see a small brass key taped to the underside of the tabletop. Unfortunately, you can't reach it.";

						if(Input.GetKeyDown(KeyCode.W)){
							currBranch = 0;
							currObjt = "null";
						}
				}
			}
		}
			
		else if(currRoom == 2){
			if(currObjt == "null"){
				// is player is large but doesnt have bubble tea
				if(count > 5 && !gotBTea && isLarge){
					textBuffer = "\nYou are stuck forever and ever.\n\nBAD END";
					textBuffer += "\n[Q] Start over";

					if(Input.GetKeyDown(KeyCode.Q)){
						Start();
					}
				}else{

					textBuffer += getRoomDescrip();	// room description

					textBuffer += "\n[Q] Sit on couch";
					textBuffer += "\n[W] Examine chandelier";
					textBuffer += "\n[E] Go through arched door";

					if(gotBTea)
						textBuffer += "\n[T] Take out bubble tea";
					if(gotPizza)
						textBuffer += "\n[Y] Take out pizza";

					if(Input.GetKeyDown(KeyCode.Q)){
						currObjt = "couch";
						count++;
					}else if(Input.GetKeyDown(KeyCode.W)){
						currObjt = "chandelier";
						count ++;
					}else if(Input.GetKeyDown(KeyCode.E)){
						currObjt = "door";
						count ++;
					}else if(gotBTea && Input.GetKeyDown(KeyCode.T)){	// if food items are in pocket
						currObjt = "bubbleT";
					}else if(gotPizza && Input.GetKeyDown(KeyCode.Y)){
						count ++;
						currObjt = "pizza";
					}
				}


			}else if(currObjt == "couch"){
				if(isLarge){
					textBuffer += "You are unfortunately already sitting on the couch. It's lodged into your back.";
				}else{
					textBuffer += "Comfy but covered in dust.";
				}
				textBuffer += "\n[W] Look at something else.";
				if(Input.GetKeyDown(KeyCode.W)){
					currBranch = 0;
					currObjt = "null";
				}

			}else if (currObjt == "chandelier"){
				textBuffer += "You examine the crystal chandelier.";
				if(!isLarge && !lKey)
					textBuffer += "\n[Q] Look up.";
				if(isLarge && !lKey)
					textBuffer += "\n[Q] Look closely.";
				if(lKey){
					textBuffer = "Nothing much to look at.";
				}
				textBuffer += "\n[W] Look at something else.";

				if(Input.GetKeyDown(KeyCode.Q)){
						if(!isLarge){	// discover large key
							currBranch = 1;
						}
						else{	// get large key
							currBranch = 2;
						}

				}else if(Input.GetKeyDown(KeyCode.W)){	// go back to main menu of area
					currObjt = "null";
				}

				// display messages
				if(currBranch == 1){
						textBuffer += "\nYou look up at the grand chandelier. It manages to provide light despite being covered in cobwebs and dust. You can see that there is something larger than the rest of the crystals dangling from one arm of the chandelier. ";

						if(Input.GetKeyDown(KeyCode.W)){
							currBranch = 0;
							currObjt = "null";
						}
				}else if(currBranch == 2){
						textBuffer += "\nYou see that there is a brass key tied to the end of one of the chandelier arms. You manage to untie it despite the limited space.\nYou now have a key.";

						if(Input.GetKeyDown(KeyCode.W)){
							lKey = true;
							currBranch = 0;
							currObjt = "null";
						}
				}

			}else if(currObjt == "door"){
				if(isLarge){
					textBuffer += "You definitely cannot fit through the doorway. ";
					textBuffer += "\n[W] Look at something else.";
					if(Input.GetKeyDown(KeyCode.W)){
						currBranch = 0;
						currObjt = "null";
					}
				}
				else{	// go to room 1
					currRoom = 1;
					currObjt = "null";	// reset for next room
				}
				
			}else if(currObjt == "bubbleT"){
				bubbleTea();
			}else if(currObjt == "pizza"){
				pizza();
			}
		}

		GetComponent<Text>().text = textBuffer;
	}

	// helper function for outputting room descriptions
	string getRoomDescrip(){
		string descrip = "";
		if (currRoom == 1) {	// large hallway
			if(isLarge){
				descrip += "You are in a long, dim hallway lined with solid wood panels on both sides. The floor is covered in a fading carpet that might have once been red. There is a heavy wooden door at the end of the hallway. In front of you is an ornately carved wooden table with curved legs.\n";
				if(!gotBTea)
					descrip += "On top of the table sits a cup of bubble tea. ";
				if(!gotPizza && !first){
					descrip += "You presume the pizza slice is still under the table, but it is too small to see.";
				}
				descrip += "To your left is a tiny, arched door that is around a foot tall.\n";
			}
			else{
				descrip += "You are in a room of a much larger scale. It is dimly lit but you can make out the tall wooden door at the end of the hallway. You are standing below the ornate wooden table.\n";
				if(!gotBTea)
					descrip += "You presume the bubble tea is still on the table, but you cannot see or reach it. ";
				if(!gotPizza)
					descrip += "Nearby on the floor, there is a slice of cheese pizza on a cheap paper plate. ";
				descrip += "To your left is a relatively regular sized arched doorway.\n";
			}
		} else if (currRoom == 2) {	// small room
			if(!isLarge){
			descrip += "You are in a sparse room covered in wallpaper with fading floral designs. There are carved wooden couches upholstered in worn plush fabric. Above you hangs a dusty gilded chandelier with many dangling crystals. Behind you is the arched door you came in from.\n";
			}
			else{
				descrip +="Your body is crouched with your knees hitting the far wall and your back against the wall with the door. Your head is pushed up against the crystal chandelier. There is barely enough room for you to move your arms but with difficulty, you are able to.\n";
			}
		}
		return descrip;
	}

	// helper function for using bubble tea
	void bubbleTea(){
		textBuffer += "You pick up the plastic cup. The cup is cold and you feel the condensation dripping onto your hands. You look closely at the contents and see that it's your favorite flavor, milk tea.\nOn the plastic seal, \"DRINK ME\" is printed.";
		if(isLarge || gotBTea){
			textBuffer += "\n[Q] Drink";
			if(currBranch != 2)	// dont display option to put in pocket if player just put in pocket
				textBuffer += "\n[W] Put in pocket";
		}
		if(!gotBTea && isLarge)
			textBuffer += "\n[E] Put down";
		else if (!gotBTea && !isLarge)
			textBuffer += "\n[E] Look at something else";	// became small without putting in pocket

		if(Input.GetKeyDown(KeyCode.Q)){	// drink
			if(!isLarge)
				currBranch2 = 1;	// if already small
			else
				currBranch = 0;	// if large
			isLarge = false;
			first = false;
			currBranch = 1;

		}else if(Input.GetKeyDown(KeyCode.W)){	// put in pocket
			gotBTea = true;
			currBranch = 2;

		}else if(Input.GetKeyDown(KeyCode.E) && !gotBTea){	// go back to main menu of area
			currBranch = 0; // reset
			currObjt = "null";
		}

		// display messages
		if(currBranch == 1){
			textBuffer += "\nYou take a sip. Yummy! ";
			if(currBranch2 != 1){	// if currently large
				if(!gotBTea){	// if bubble tea not in pocket
					textBuffer += "You put the cup down. ";
				}
				textBuffer += "The room starts to expand...wait no. You're shrinking and shrinking. You are now less than a foot tall.";
			}else{	// already small
				textBuffer += "But nothing happens. Hm.";
			}

		}else if(currBranch == 2){
				textBuffer += "\n[E] Look at something else";
				textBuffer += "\nYou somehow get the bubble tea into your pocket.";

				if(Input.GetKeyDown(KeyCode.E)){
					currBranch = 0;
					currObjt = "null";
				}
		}

	}
	// helper function for using pizza
	void pizza(){
		textBuffer += "You pick up the paper plate - it's warm. The pizza is the perfect balance of greasy and cheesy.\nOn the paper plate, \"EAT ME\" is written.";
		
		if(!isLarge || gotPizza){
			textBuffer += "\n[Q] Eat";
			if(currBranch != 2)	// dont display option to put in pocket if player just put in pocket
				textBuffer += "\n[W] Put in pocket";
		}

		if(!gotPizza && !isLarge)
			textBuffer += "\n[E] Put down";
		else if (!gotPizza && isLarge)
			textBuffer += "\n[E] Look at something else";	// became large without putting in pocket

		if(Input.GetKeyDown(KeyCode.Q)){	// eat
			if(isLarge)
				currBranch2 = 1;	// if already large
			else
				currBranch2 = 0;	// if small
			isLarge = true;
			currBranch = 1;

		}else if(Input.GetKeyDown(KeyCode.W)){	// put in pocket
			gotPizza = true;
			currBranch = 2;

		}else if(Input.GetKeyDown(KeyCode.E) && !gotPizza){	// go back to main menu of area
			currBranch = 0; // reset
			currObjt = "null";
		}

		// display messages
		if(currBranch == 1){
			textBuffer += "\nYou take a bite. So good... ";
			if(currBranch2 != 1){	// if currently small
				if(!gotPizza){	// if pizza not in pocket
					textBuffer += "You put the pizza down. ";
				}
				textBuffer += "Your line of vision rises as you grow back to your original size. Cool.";
			}else{	// already large
				textBuffer += "But nothing happens. Hm.";
			}

		}else if(currBranch == 2){
				textBuffer += "\n[E] Look at something else";
				textBuffer += "\nYou somehow get the pizza into your pocket.";

				if(Input.GetKeyDown(KeyCode.E)){
					currBranch = 0;
					currObjt = "null";
				}
			}
	}

}


