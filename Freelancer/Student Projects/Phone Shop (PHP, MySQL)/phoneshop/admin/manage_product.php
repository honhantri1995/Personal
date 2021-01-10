<?php
	if (isset($_GET['action']) && $_GET['action'] == "delete") {
		deleteProduct($_GET['product_id']);
	}

	function getProducts()
	{
		require("../config.php");

		$query = "SELECT *, category.name as category, product.id as id, product.name as name FROM product
				  INNER JOIN category WHERE product.category_id = category.id";
		$result = $con->query($query);

		if ($result == false) {
			echo "ERROR: Get products failed:\n" . $con->error;
			$con->close();
			return;
		}

		$all_rows = array();
		while ($row = $result->fetch_assoc()) {
			array_push($all_rows, $row);
		}

		$con->close();
		return $all_rows;
	}

	function deleteProduct($id)
	{
		require("../config.php");

		$query = "DELETE FROM product WHERE id = ".$id;
		$result = $con->query($query);

		if ($result == false) {
			echo "ERROR: Delete product failed:\n" . $con->error;
		}

		$con->close();
	}

?>

<!DOCTYPE html>
<html>

<head>
	<link rel="stylesheet" href="css/table_gridview.css">
	<link rel="stylesheet" href="css/btn.css">
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>

<body>
	<?php
		require("side_nav.php");
	?>

	<div class="table-gridview-container">
		<table class="table-gridview">
			<tr>
				<th>ID</th>
				<th>Name</th>
				<th>Category</th>
				<th>Company</th>
				<th>Price</th>
				<th>Availability</th>
				<th>Action</th>
			</tr>

<?php
				foreach ($pros = getProducts() as $pro) {
?>
					<tr>
						<td><?php echo $pro['id']; ?></td>
						<td><?php echo $pro['name']; ?></td>
						<td><?php echo $pro['category']; ?></td>
						<td><?php echo $pro['company']; ?></td>
						<td><?php echo $pro['price']; ?></td>
						<td><?php echo $pro['availability']; ?></td>
						<td>
							<a href="edit_product.php?product_id=<?php echo $pro['id']; ?>&action=edit" >
							<button class="btn" ><i class="fa fa-edit"> Edit</i></button>
							
							<a href="manage_product.php?product_id=<?php echo $pro['id']; ?>&action=delete" >
							<button class="btn" ><i class="fa fa-trash"> Delete</i></button>
						</td>
					</tr>
<?php
				}
?>
		</table>
	</div>


</body>

</html>