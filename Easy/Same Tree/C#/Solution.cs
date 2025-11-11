using System;

namespace Same_Tree;

public class Solution {
	public bool IsSameTree(TreeNode? p, TreeNode? q) {
		if (p == null && q == null) return true;
		if (p == null || q == null || p.val != q.val) return false;

		return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
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
