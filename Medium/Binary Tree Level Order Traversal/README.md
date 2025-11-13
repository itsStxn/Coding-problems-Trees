# Binary Tree Level Order Traversal

## Description
Given the `root` of a binary tree, return the level *order traversal of its nodes' values*. (i.e., from left to right, level by level).

### Example 1
**Input**: `root` = [3,9,20,null,null,15,7]  
**Output**: [[3],[9,20],[15,7]]  

### Example 2
**Input**: `root` = [1]  
**Output**: [[1]]  

### Example 3
**Input**: `root` = []  
**Output**: []  

### Constraints
The number of nodes in the tree is in the range `[0, 2000]`.  
-1000 <= `Node.val` <= 1000

## Strategy
Use a queue to move through the nodes of the tree. Enqueue the `left` and `right` pointers of each node. To gather all the nodes of a level, simply use a loop to empty the queue, and make sure to store the nodes in a list of lists. While emptying the list, enqueue the next pointers, if there are any. 

## Time Complexity - O(n)
Each node gets processed once.

## Space Complexity - O(n)
A list of lists and a queue both have sizes that depend on `n` nodes
