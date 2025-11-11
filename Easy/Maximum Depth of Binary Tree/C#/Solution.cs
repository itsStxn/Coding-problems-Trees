using System;

namespace Maximum_Depth_of_Binary_Tree;

public class Solution {
	public int MaxDepth(TreeNode? root) {
		if (root == null) return 0;

		int fromLeft = 1 + MaxDepth(root.left);
		int fromRight = 1 +  MaxDepth(root.right);

		return Math.Max(fromLeft, fromRight);	
	}
}

public class TreeNode {
	public int val;
	public TreeNode? left;
	public TreeNode? right;
	private TreeNode? curr = null;
	private readonly string id = Guid.NewGuid().ToString();

	public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null) {
		this.val = val;
		this.left = left;
		this.right = right;
	}

	public TreeNode AddLeft(int value) {
		curr ??= this;
		curr.left = new TreeNode(value);
		curr = curr.left;
		return this;
	}

	public TreeNode AddRight(int value) {
		curr ??= this;
		curr.right = new TreeNode(value);
		curr = curr.right;
		return this;
	}

	public TreeNode AddLeft(TreeNode node) {
		curr ??= this;
		curr.left = node;
		curr = curr.left;
		return this;
	}

	public TreeNode AddRight(TreeNode node) {
		curr ??= this;
		curr.right = node;
		curr = curr.right;
		return this;
	}

	public override string ToString() {
		var output = new List<int>();
		var visited = new HashSet<string>();
		var stack = new Stack<TreeNode>();
		stack.Push(this);

		while (stack.Count > 0) {
			var node = stack.Pop();
			if (node == null || !visited.Add(node.id))
				continue;

			output.Add(node.val);

			if (node.right != null)
				stack.Push(node.right);
			if (node.left != null)
				stack.Push(node.left);
		}

		return string.Join(", ", output);
	}
}
