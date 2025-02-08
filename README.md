# Virtual Reality Supermarket Experience

This application is built to assess children's (age 5-12 years old) behaviour in selecting cereal goods in a supermarket. Software is deployable in Meta Quest 1, 2, 3, and Pro devices, and will require two controllers to operate.
[![Cycle cave set up image](OculusScreenshot.png)](https://drive.google.com/file/d/1wGBI9Ie7PLrBYNmKD6WfWDiolt9W1tfu/view?usp=sharing)
Click the image above to preview the demonstration video

## Software Overview
* The software begins with character selection and UID selection. Ensure that the character and UID displayed on the mirror match your choices before pressing the left trigger to proceed.
* Users can clench and unclench their virtual hands. Grabbing a cereal object is possible by performing this action while in contact with the object.
* (During data collection) Users receive verbal instructions to select a cereal they want to eat and place it on the cashier's table.
* (During data collection) Users are also verbally instructed to choose a healthy cereal and place it on the cashier's table.
* Verbal instructions are used because the application is deployed in a noisy environment, reducing reliance on the software’s speaker. Additionally, some children may be too young to read.
* Collected data can be found in a CSV file in the project system folder of the oculus device Android > data > com.DefaultCompany.VR_Sciencework > files
* Data collected: UID, date, object grabbed, time of grab, time of release, whether the object is the first purchase, and whether the object is the second purchase.

## Input System
* **Right trigger**: Switch character during selection; grabbing objects with right hand (cereal boxes)
* **Left trigger**: Finalise character + user ID; grabbing objects with left hand (cereal boxes)
*  **A button**: decrease UID by 1
*  **B button**: increase UID by 10
*  **X button**: decrease UID by 10
*  **Y button**: increase UID by 10
  


### Dependencies

* Unity 2022.3.27f
* Windows system
* Autohand assets
* TextMeshPro 3.0.7



## Common issues and advise
* The user body rig system is not perfect, continously switching between girl and boy avatar may mess the size of the limbs, it's recommended to switch less than two times and to reset the application if there is limb issues.
  
## Authors
* Farah Farizi - https://github.com/farahfarizi24 / farahdfarizi@gmail.com
