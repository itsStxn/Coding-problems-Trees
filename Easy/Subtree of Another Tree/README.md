# Subtree of Another Tree

## Description
Given the roots of two binary trees `root` and `subRoot`, return true if there is a subtree of `root` with the same structure and node values of `subRoot` and false otherwise.

A subtree of a binary tree `tree` is a tree that consists of a node in `tree` and all of this node's descendants. The tree `tree` could also be considered as a subtree of itself.

### Example 1
**Input**: `root` = [3,4,5,1,2], `subRoot` = [4,1,2]  
**Output**: true  

### Example 2
**Input**: `root` = [3,4,5,1,2,null,null,null,null,0], `subRoot` = [4,1,2]  
**Output**: false  

### Constraints
The number of nodes in the root tree is in the range `[1, 2000]`.  
The number of nodes in the subRoot tree is in the range `[1, 1000]`.  
-104 <= `root.val` <= 104  
-104 <= `subRoot.val` <= 104

## Strategy
Recursively move to the `left` and `right` of `root`. If the value of `root` or one his his nodes is the same as `subRoot`, recursively check if they share the same descendants and structure.  

## Time Complexity - O(n*m)
With `n` and `m` being respectively the nodes of `root` and `subRoot`. If an `n`  node in `root` has the same value of `subRoot`, an `m` check happens.

## Space Complexity - O(h_root + h_subRoot)
When checking if a node of `root` has the same value of `subRoot`, there is a check that depends on the height of both trees.
