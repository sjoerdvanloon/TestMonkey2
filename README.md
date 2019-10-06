# TestMonkey2

The test is a seperate entity from the queue of command, and the logging is also seperate, but a lot cleaner (handled in the queue, just as a tree)
So two trees and a queue. The scopes, teardown and test are put into stacks (maybe scope en test are combined in a tuple, because, why not)

About the commands, before the execution of the command is called, a lot could have been done, eg: elements could have been found on the page, variables, parameters and choices could be sanatized.
The nicest thing would be if I could get it as far as that the input parameters are no longer only context, but really the actual elements, choices etc in the correct order, fully initialized and even checked.

About the elements, maybe it would be a good id to have the structure of the element tree represented as classes, this way for the controls I could just do GetID(), which finds the parents etc etc. More could be validated

The engine would be a lot stricter, but also much more clearer, less recursing, less trees and less repeating code would be needed. Also I could learn and apply a thing or two I've learned in the last 5 years.
