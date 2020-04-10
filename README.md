# Synthetic Data Generator from 3D Model (Work In Progress)

AIM: TO IDENTIFY A APPROPRIATE METHOD TO GENERATE SYNTHETIC DATA WHICH CAN BE USED TO TRAIN PRETRAINED CLASSIFICATION MODELS.

Synthetic data generation in Unity3D, utilizing its superior graphics processing capability to make realistic synthetic data 
which can be used to for tasks from key point detection, object localization, heatmaps and classification.

NOTE: This is a reimplementation from scratch of version 0.1, better organised and optimized code.

### 3D MODELS

The 3d models are obtained from [ShapeNet Dataset](https://www.shapenet.org/)

For prototyping selected classes of random objects are spawned far away from the Camera, while the target(knife in the below example) object is spawned infront. For further simplicity we are ignoring complex real world scenarios also, which we plan on implementing further down the road.

Here are two train images for a knife the system generated:

![Alt Text](https://github.com/Fathaah/SynEnv/blob/master/images/1.PNG)    ![Alt Text](https://github.com/Fathaah/SynEnv/blob/master/images/2.PNG)

## TO DO

* **Benchmarking the synthetic images**.
* Improve the Object spawning technique to get all the areas. 


* Change the Background of the walls, randomized textures.


* The intraction of lighting to different objects should be made more realistic.





* Create a GAN which reduces test loss by appropriately synthesysing the background pixels to the different poses.



# Synthetic Data Generator from 3D Model old version(Work In Progress)

This is an old reference version of the code, this was created in 2017 and requires lot of polishing. The files in this directory were uused for the following tasks:

* Generation of a depth dataset, the program was capable of generating a synthetic scene by randomly spawning objects then the view is used to generate the depth map from the distace from camera.

* Hand pose detection, a random hand pose in varying orientation was generated and keypoints were determined and stored in a file.


