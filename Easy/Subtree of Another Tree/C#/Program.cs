using Subtree_of_Another_Tree;

var task = new Solution();
var root = new TreeNode(3, new(4, new(1), new(2)), new(5));
var sub = new TreeNode(4, new(1), new(2));

var result = task.IsSubtree(root, sub);
Console.WriteLine(result);
