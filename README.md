# Game of Life
C# application for the simulation of life, represented by visual cells within an "infinite" grid structure, following a predefined ruleset.

# Assumptions
The representation of infinite in computing is theoretically impossible and the increase in size of a grid would exponentially increase the computational processing power required. Therefore, within the context of this scenario, the term “infinite” is assumed to be an adjective referring to a large quantity and hence, a grid can be constructed using numbers between a fixed minimum and maximum amount, instead of the mathematical concept of infinity.

As the scenario suggests the application’s purpose is to simulate life through turns, it is assumed the user may wish to automate turn transitions with the capability to pause, amend, resume and stop. Therefore, these functions are included within the program to pause simulation, change the state of cells, resume simulation with or without changes and end the simulation at any time.

Finally, it is assumed that the most user-friendly methodology of inputting and outputting cell state information within a grid would be visually using visual elements. As such, cell states are represented through colour and the program utilises a graphical user interface (GUI) over a console based application. 
