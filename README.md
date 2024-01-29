# Pendulum Knee Drop Test
Simulation of Pendulum Knee Drop Test (Wartenberg Pendulum Test) in Unity 3D.

Wartenberg Pendulum Test is a test of assesing spasticity while measuring passive knee motion [1]. This program simulates this test in Unity 3D for normal tone, 3 levels of spasticity (mild, moderate and severe) and clasp knife spasticity. Clasp knife spasticity refers to increased resistance (muscle tone) at the start of passive motion (muscle stretch) followed by sudden reduction in resistance as the motion progresses [2]. This program outputs three data measures: velocity, angular velocity and number of oscillations which can further be plotted in the program of choice, such as MATLAB (or matplotlib for Python).

## Analysis
Please refer to graphs below (plotted in MATLAB). Clasp knife spasticity can easily be distinguished from rest of the cases in terms of number of oscillations, velocity peak and sudden drop in degree of angle.

### Number of oscillations
Graph showing number of oscillations in each case of spasticity
![Number_of_oscillations](https://github.com/drchiragmotwani/PKD_simulation/assets/157987275/15b00d57-1848-4c65-a6e7-1b7776a0167f)

### Velocity graph
Graph of velocity showing patterns of peaks for each case of spasticity
![Velocity_graph](https://github.com/drchiragmotwani/PKD_simulation/assets/157987275/f025b511-dda4-4701-bb7e-ef376efaa4d8)

### Angle graph
Graph showing angular data for each case of spasticity
![Angle_graph](https://github.com/drchiragmotwani/PKD_simulation/assets/157987275/661f3ac0-0a9b-4ed5-800c-4170720da2d3)

## Video Demo
https://youtu.be/UpEXNICHZss

## References
[1] Valle MS, Casabona A, Sgarlata R, Garozzo R, Vinci M, Cioni M. The pendulum test as a tool to evaluate passive knee stiffness and viscosity of patients with rheumatoid arthritis. BMC Musculoskelet Disord. 2006 Nov 29;7:89. doi: 10.1186/1471-2474-7-89. PMID: 17134492; PMCID: PMC1693559.   
[2] https://www.ncbi.nlm.nih.gov/medgen/1643622
