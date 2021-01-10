<?php
	if (isset($_GET['action']) && $_GET['action'] == "delete") {
		deleteOrder($_GET['order_id']);
	}

	function getProductOrderInfo()
	{
		require("../config.php");

		$query = "SELECT *, product_orders.id AS order_id FROM ((product_orders
				  INNER JOIN product ON product_orders.product_id = product.id)
				  INNER JOIN account_customer ON product_orders.customer_username = account_customer.username)";
		$result = $con->query($query);

		if ($result == false) {
			echo "ERROR: Get product order details failed:\n" . $con->error;
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

	function deleteOrder($id)
	{
		require("../config.php");

		$query = "DELETE FROM product_orders WHERE id = ".$id;
		$result = $con->query($query);

		if ($result == false) {
			echo "ERROR: Delete order failed:\n" . $con->error;
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
				<th>Order ID</th>
				<th>Product ID</th>
				<th>Product Name</th>
				<th>Product Price</th>
				<th>Quantity</th>
				<th>Total Price</th>
				<th>Fullname</th>
				<th>Gender</th>
				<th>Address</th>
				<th>Phone</th>
				<th>Email</th>
				<th>Action</th>
			</tr>

<?php
				foreach ($ords = getProductOrderInfo() as $ord) {
?>
					<tr>
						<td><?php echo $ord['order_id']; ?></td>
						<td><?php echo $ord['product_id']; ?></td>
						<td style="font-weight: bold"><?php echo $ord['name']; ?></td>
						<td><?php echo $ord['price']; ?></td>
						<td style="font-weight: bold"><?php echo $ord['quantity']; ?></td>
						<td style="font-weight: bold; color: red"><?php echo $ord['total_price']; ?></td>
						<td style="font-weight: bold"><?php echo $ord['fullname']; ?></td>
						<td><?php echo $ord['gender']; ?></td>
						<td style="font-weight: bold"><?php echo $ord['address']; ?></td>
						<td style="font-weight: bold"><?php echo $ord['phone']; ?></td>
						<td><?php echo $ord['email']; ?></td>
						<td>						
							<a href="manage_order.php?order_id=<?php echo $ord['order_id']; ?>&action=delete" >
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