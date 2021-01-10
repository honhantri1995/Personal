<?php
	// Initializing the session 
	session_start(); 

	$product = getProduct();

	function getProduct()
	{
		require("config.php");

		$query = "SELECT * FROM product WHERE id = ".$_SESSION['product_id'];
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

	function getTotalPrice()
	{
		global $product;
		$price = intval($_POST['quantity']) * $product['price'];
		$_SESSION['total_price'] = $price;

		return $price;
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

	<form method="POST" enctype="multipart/form-data" action="order_product.php">
		<div class="form-container-1" >
			<div>
				<p>Here is the price: </p>
				<br>
			</div>

			<div class="form-group">
				<label class="label" for="basicinput">Quantity *</label>
				<input class="form" type="text" name="quantity" value="<?php echo $_POST['quantity']; ?>" readonly>
			</div>

			<div>
				<br>
				<br>
				<p><?php echo $_POST['quantity']; ?> x <?php echo $product['price']; ?></p>
				<p>--------------</p>
				<p style="font-weight: bold; color: red;"><?php echo getTotalPrice(); ?></p>
			</div>

		</div>

<?php
		if (isset($_SESSION['username']) == false) {
?>
			<div class="form-container-2">
				<div>
					<p>Please enter your information: </p>
					<br>
				</div>
	
					<div class="form-group">
						<label class="label" for="basicinput">Full name *</label>
						<input class="form" type="text" name="fullname" required>
					</div>
					
					<div class="form-group">
						<label class="label" for="basicinput">Gender *</label>
						<select class="form" name="gender" required>
							<option value="Male">Male</option>
							<option value="Female">Female</option>
						</select>
					</div>
	
					<div class="form-group">
						<label class="label" for="basicinput">Phone *</label>
						<input class="form" type="text" name="phone" required>
					</div>
				
					<div class="form-group">
						<label class="label" for="basicinput">Address *</label>
						<textarea class="form" name="address" style="height: 100px" required></textarea>
					</div>
	
					<div class="form-group">
						<label class="label" for="basicinput">Email</label>
						<input class="form" type="text" name="email">
					</div>
		
					<div class="form-group" >
						<button class="submit_btn buy_btn" type="submit" name="order_btn">ORDER</button>
					</div>
				</div>
			</div>
<?php
		}
		else {
?>
			<div class="form-container-2">
				<div>
					<p>Please enter your information: </p>
					<br>
				</div>
	
					<div class="form-group">
						<label class="label" for="basicinput">Full name *</label>
						<input class="form" type="text" name="fullname" value="<?php echo $_SESSION['fullname']; ?>" required>
					</div>
					
					<div class="form-group">
						<label class="label" for="basicinput">Gender *</label>
						<select class="form" name="gender" value="<?php echo $_SESSION['gender']; ?>" required>
							<option value="Male">Male</option>
							<option value="Female">Female</option>
						</select>
					</div>
	
					<div class="form-group">
						<label class="label" for="basicinput">Phone *</label>
						<input class="form" type="text" name="phone" value="<?php echo $_SESSION['phone']; ?>" required>
					</div>
				
					<div class="form-group">
						<label class="label" for="basicinput">Address *</label>
						<textarea class="form" name="address" style="height: 100px" required> <?php echo $_SESSION['address']; ?> </textarea>
					</div>
	
					<div class="form-group">
						<label class="label" for="basicinput">Email</label>
						<input class="form" type="text" name="email" value="<?php echo $_SESSION['email']; ?>>" required>
					</div>
	
					<div class="form-group" >
						<button class="submit_btn buy_btn" type="submit" name="order_btn">ORDER</button>
					</div>
				</div>
			</div>
<?php
		}
?>

	</form>


</body>

</html>