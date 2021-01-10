<?php
	// Global variables
	$row_product = array();

	if (isset($_GET['action']) && $_GET['action'] == "edit") {
		$row_product = getProductInfo($_GET['product_id']);
	}

	if(isset($_POST['submit_btn']))
	{
		edit();
	} 

	function getProductInfo($id)
	{
		require("../config.php");

		$query = "SELECT *, product.name as productName FROM product
				  INNER JOIN category ON product.category_id = category.id
				  WHERE product.id = ".$id;
		$result = $con->query($query);
	
		if ($result == false) {
			echo "ERROR: Edit product failed:\n" . $con->error . "\nYour query: " . $query;
			$con->close();
			return "";
		}
	
		$row = $result->fetch_assoc();
		$con->close();

		return $row;
	}

	function getCategories()
	{
		require("../config.php");

		$query = "SELECT * FROM category";
		$result = $con->query($query);

		if ($result == false) {
			echo "ERROR: Edit product failed:\n" . $con->error . "\nYour query: " . $query;
			return "";
		}
	
		$rows = null;
		while ($row = $result->fetch_assoc()) {
			$rows[$row['id']] = $row['name'];
		}

		return $rows;
	}

	function edit()
	{
		require("../config.php");

		$category_id = $_POST['category_id'];
		$productName = $_POST['name'];
		$productCompany = $_POST['company'];
		$productPrice = $_POST['price'];
		$productAvailability = $_POST['availability'];
		$productDescription = $_POST['description'];

		$productImage = $_FILES["file"]["name"];
		global $row_product;
		if ($productImage == "") {
			$productImage = $row_product['image'];
		}
		else {
			echo "file: ".'../'.$row_product['image'];
			if(file_exists('../'.$row_product['image'])) {
				chmod('../'.$row_product['image'], 0755); 	// Change the file permissions if allowed
				unlink('../'.$row_product['image']); 		// Remove the file
			}
			echo "source path = ".$_FILES["file"]["tmp_name"];
			echo "des path = "."../images/".$_GET['product_id']."_".$productImage;
			move_uploaded_file($_FILES["file"]["tmp_name"], "../images/".$_GET['product_id']."_".$productImage);
			$productImage = "images/".$_GET['product_id']."_".$productImage;
		}

		$query = "UPDATE product SET category_id = ".$category_id.", name = '".$productName."', company = '".$productCompany."', price = ".$productPrice.", availability = '".$productAvailability."', description = '".$productDescription."', image = '".$productImage."' WHERE id=".$_GET['product_id'];
		$result = $con->query($query);

		$dir = "../images/".$_GET['product_id'];

		if ($result) {
			echo "Edit product successfully!";
		}
		else {
			echo "ERROR: Edit product failed!\n" . $con->error . "\nYour query: " . $query;
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
				<select class="form" name="category_id">
<?php
					$selected = "";
					foreach ($cats = getCategories() as $key => $value) {
						if ($key == $row_product['category_id']) {
							$selected = "selected";
						}
						else {
							$selected = "";
						}
?>
						<option value="<?php echo $key; ?>" <?php echo $selected; ?> ><?php echo $value; ?></option>
<?php
					}
?>
				</select>
			</div>
		
			<div class="form-group">
				<label class="label" for="basicinput">Product Name *</label>
				<input class="form" type="text" name="name" value="<?php echo $row_product['productName']; ?>">
			</div>
		
			<div class="form-group">
				<label class="label" for="basicinput">Company *</label>
				<input class="form"  type="text" name="company" value="<?php echo $row_product['company']; ?>">
			</div>
	
			<div class="form-group">
				<label class="label" for="basicinput">Price *</label>
				<input class="form" type="text" name="price" value="<?php echo $row_product['price']; ?>">
			</div>
		
			<div class="form-group">
				<label class="label" for="basicinput">Description *</label>
				<textarea class="form" name="description" style="height: 100px"><?php echo $row_product['description']; ?></textarea>
			</div>
		
			<div class="form-group">
				<label class="label" for="basicinput">Availability *</label>
				<select class="form" name="availability" id="Availability" >
<?php
					if ($row_product['availability'] == "In stock") {
?>
						<option value="In stock" selected >In stock</option>
						<option value="Out of stock" >Out of stock</option>
<?php
					}
					else {
?>
						<option value="In stock" >In stock</option>
						<option value="Out of stock" selected >Out of stock</option>
<?php
					}
?>
				</select>
			</div>
		
			<div class="form-group">
				<label class="label" for="basicinput">Image *</label>
				<input class="form" type="file" name="file" id="Image" >
				<p style="margin-left: 20%;">Current image: <?php echo $row_product['image']; ?></p>
			</div>
		
			<div class="form-group" onclick="edit_product.php">
				<button class="submit_btn" type="submit" name="submit_btn">Edit Product</button>
			</div>

		</form>

	</div>


</body>

</html>