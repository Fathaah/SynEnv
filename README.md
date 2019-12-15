# Synthetic Data Generator from 3D Model (Work In Progress)

AIM: TO IDENTIFY A APPROPRIATE METHOD TO GENERATE SYNTHETIC DATA WHICH CAN BE USED TO TRAIN PRETRAINED CLASSIFICATION MODELS.

Currently the synthetic data is generated using Unity3D, we plan on moving it to a more light weight 3D engine.

###3D MODELS

The 3d models are obtained from [ShapeNet Dataset](https://www.shapenet.org/)

For prototyping selected classes of random objects are spawned far away from the Camera, while the target object is spawned infront. For further simplicity we are ignoring complex real world scenarios also, which we plan on implementing further down the road.

Here are two train images for a knife the system generated:

[!Alt Text](https://github.com/Fathaah/SynEnv/blob/master/images/1.PNG)    [!Alt Text](https://github.com/Fathaah/SynEnv/blob/master/images/2.PNG)
