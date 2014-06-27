Coyote-Tracking-Interface
=========================
Coyote Tracking Interface (CTI) - README
Developed for: The Conservation Agency, Narragansett Bay
Developed by: Justin Crerar

User Requirements:
-Windows 7 or later
-~10 MB Physical Hard Drive Space
-Mobile Phone that supports AT commands
	-Phone must be storing texts as MT (as in Mobile Terminated) messages
	-Connection through USB cable

Required files:
-CoyoteTracking.exe
-CoyoteDatabase.mdb

Installation Instructions

1. Run CoyoteTracking.exe.
2. Follow the instructions on the installer wizard that appears.
3. After the installer has completed, save CoyoteDatabase.mdb in a location which you can remember (running the program will generate .txt files in C:\\Users\Public\CoyoteFiles , in case the user would like to group all the CTI files together.)
4. Once installed, opening the Coyote Monitor will allow the user to specify where the database is located through a typical open file dialog by clicking "Choose Path...".
5. You have then fully installed the Coyote Tracking Interface. Happy Tracking :)


A few remarks...

-HOW TO REMOVE COYOTES:
1.Navigate to C:\\Users\Public\CoyoteFiles\SaveFile.txt
2.Delete the line of the Coyote you wish to delete.
3.IMPORTANT - Please make sure there is no empty space at the top of the SaveFile.txt file, as well as make sure there is only one "{number} - {name}" per line starting from the top. The software scans for names until it runs into a blank line.

-Clicking "Monitor On" will activate the monitor to run at an interval provided by the user and write valid points to the database. Clicking "Monitor Off" will turn this process off.

-The "CattraQ(tm) Monitor" operates while the window is open and while composing commands by pressing the 'Send Command' button on the "Cattraq(tm) Monitor" window. Closing the window while the process is running will show a warning before the user can choose to close.

-There has not been a numerical limit set to the intervals which the software checks the phone for texts. Please avoid using 0 or negative numbers in the interval field or else the software will crash.

-Finally, I'd like to leave a special thanks to Dr. Numi Mitchell, Dr. Godi Fischer, and Dr. Harish Sunak for guidance on creating the software and giving me this opportunity to serve the community in a big way. Enjoy!
Coyote Tracking Interface
