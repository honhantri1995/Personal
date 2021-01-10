<?php

	if(isset($_POST['submit_btn']))
	{
		add();
	}

	function getCategories()
	{
		require("../config.php");

		$query = "SELECT * FROM category";
		$result = $con->query($query);

		if ($result == false) {
			echo "ERROR: Get categories failed:\n" . $con->error;
			$con->close();
			return "";
		}
	
		$rows = null;
		while ($row = $result->fetch_assoc()) {
			$rows[$row['id']] = $row['name'];
		}
		$con->close();

		return $rows;
	}

	function add()
	{
		require("../config.php");

		$category_id = $_POST['category_id'];
		$productName = $_POST['name'];
		$productCompany = $_POST['company'];
		$productPrice = $_POST['price'];
		$productAvailability = $_POST['availability'];
		$productDescription = $_POST['description'];

		$query = "SELECT MAX(id)  FROM product";
		$result = $con->query($query);
		$row = $result->fetch_array();
		$productId = $row['MAX(id)'] + 1;

		move_uploaded_file($_FILES["file"]["tmp_name"], "../images/".$productId."_".$_FILES["file"]["name"]);
		$prdoduct_image_path = "images/".$productId."_".$_FILES["file"]["name"];

		$query = "INSERT INTO product VALUES(".$productId.", ".$category_id.", '".$productName."', '".$productCompany."', ".$productPrice.", '".$productAvailability."', '".$productDescription."', '".$prdoduct_image_path."')";
		$result = $con->query($query);
		if ($result) {
			echo "Added product successfully!";
		}
		else {
			echo "ERROR: Added product failed!\n" . $con->error . "\nYour query: " . $query;
		}

		$con->close();
	}
?>

<!DOCTYPE html>
<html>

<head>
	<link rel="stylesheet" href="css/form.css">
	<link rel="stylesheet" href="css/btn.css">
</head>

<body>
	<?php
		require("side_nav.php");
	?>

	<div class="form-container">

		<form method="POST" enctype="multipart/form-data">

			<div class="form-group">
				<label class="label" for="basicinput">Category *</label>
				<select class="form" name="category_id" required>
					<option value="">Select category</option>
					<?php
						foreach ($cats = getCategories() as $key => $value) { 
					?>
							<option value="<?php echo $key; ?>"> <?php echo $value; ?> </option>
					<?php
						}
					?>
				</select>
			</div>
		
			<div class="form-group">
				<label class="label" for="basicinput">Product Name *</label>
				<input class="form" type="text" name="name" required>
			</div>
		
			<div class="form-group">
				<label class="label" for="basicinput">Company *</label>
				<input class="form"  type="text" name="company" >
			</div>
	
			<div class="form-group">
				<label class="label" for="basicinput">Price *</label>
				<input class="form" type="text" name="price" required>
			</div>
		
			<div class="form-group">
				<label class="label" for="basicinput">Description *</label>
				<textarea class="form" name="description" style="height: 100px" required></textarea>
			</div>
		
			<div class="form-group">
				<label class="label" for="basicinput">Availability *</label>
				<select class="form" name="availability" id="Availability" required>
					<option value="In Stock">In Stock</option>
					<option value="Out of Stock">Out of Stock</option>
				</select>
			</div>
		
			<div class="form-group">
				<label class="label" for="basicinput">Image *</label>
				<input class="form" type="file" name="file" id="Image" required>
			</div>
		
			<div class="form-group" onclick="add_product.php">
				<button class="submit_btn" type="submit" name="submit_btn">Add Product</button>
			</div>

		</form>

	</div>


</body>

</html>