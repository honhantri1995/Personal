<?php
	$pid = $_GET['product_id'];

	// Initialize the session 
	session_start(); 
	$_SESSION['product_id'] = $pid;

	$product = getProduct();
	$product_details = getProductDetails();

	function getProduct()
	{
		require("config.php");

		global $pid;
		$query = "SELECT * FROM product WHERE id = ".$pid;
		$result = $con->query($query);

		if ($result == false) {
			echo "ERROR: Get products failed:\n" . $con->error;
			$con->close();
			return;
		}

		$row = $result->fetch_assoc();

		$con->close();
		return $row;
	}
	
	function getProductDetails()
	{
		require("config.php");

		global $pid;
		$query = "SELECT * FROM product_details WHERE product_id = ".$pid;
		$result = $con->query($query);

		if ($result == false) {
			echo "ERROR: Get product details failed:\n" . $con->error;
			$con->close();
			return;
		}

		$row = $result->fetch_assoc();

		$con->close();
		return $row;
	}
?>

<!DOCTYPE html>

<html>

<head>
	<link rel="stylesheet" href="./css/form.css">
	<link rel="stylesheet" href="./css/product_page.css">
</head>


<body>
	<?php
		require("top_nav.php");
	?>

	<div>
		<h2 class="product-name"><?php echo $product['name']; ?></h2>
	</div>

	<div class="image-container">
		<img class="image" src="<?php echo $product['image']; ?>">
	</div>

	<div class="product-info-table-container">
		<table class="product-info-table">
			<tr>
				<td>Name</td>
				<td><?php echo $product_details['name']; ?></td>
			</tr>
			<tr>
				<td>Display</td>
				<td><?php echo $product_details['display']; ?></td>
			</tr>
			<tr>
				<td>CPU</td>
				<td><?php echo $product_details['cpu']; ?></td>
			</tr>
			<tr>
				<td>RAM</td>
				<td><?php echo $product_details['ram']; ?></td>
			</tr>
			<tr>
				<td>ROM</td>
				<td><?php echo $product_details['rom']; ?></td>
			</tr>
			<tr>
				<td>Front camera</td>
				<td><?php echo $product_details['camera_front']; ?></td>
			</tr>
			<tr>
				<td>Back camera</td>
				<td><?php echo $product_details['camera_back']; ?></td>
			</tr>
			<tr>
				<td>OS</td>
				<td><?php echo $product_details['os']; ?></td>
			</tr>
			<tr>
				<td>SIM</td>
				<td><?php echo $product_details['sim']; ?></td>
			</tr>
			<tr>
				<td>Security</td>
				<td><?php echo $product_details['security']; ?></td>
			</tr>
			<tr>
				<td>Pin</td>
				<td><?php echo $product_details['pin']; ?></td>
			</tr>
			<tr>
				<td>Color</td>
				<td><?php echo $product_details['color']; ?></td>
			</tr>
		</table>
	</div>

	<div class="form-container-1" >
		<div>
			<p>How many products you want to buy: </p>
			<br>
		</div>

		<form method="POST"  action="buy_product.php">
			<div class="form-group">
				<label class="label" for="basicinput">Quantity *</label>
				<input class="form" type="text" name="quantity" value="1" required>
			</div>

			<div class="buy-btn-container" >
				<input class="buy_btn" type="submit" name="buy_btn" value="BUY IT NOW">
			</div>
		</form>
	</div>

	
</body>

</html>