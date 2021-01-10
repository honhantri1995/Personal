<?php
	function getProducts_ForEachCategory()
	{
		require("config.php");

		$cid = $_GET['category_id'];

		$query = "SELECT * FROM category WHERE id = " . $cid;
		$result = $con->query($query);

		while ($row = $result->fetch_assoc()) {
			$query = "SELECT * FROM product WHERE category_id = " . $cid;
			$result = $con->query($query);
			if ($result->num_rows > 0) {
				$i = 1;
				echo '<table class="container">';
				while ($row = $result->fetch_assoc()) {
					if ($i == 1) {
						echo '<tr>';
					}

					echo '
						<td>
							<a href="product.php?category_id='.$cid.'&product_id='.$row['id'].'">
								<img src="'.$row['image'].'"/>
							</a>
							<h5>'.$row['name'].'</h5>
							<h6>'.$row['price'].'</h6>
						</td>
					';

					if ($i == 4) {
						echo '</tr>';
						$i = 0;
					}
					$i++;
				}
				echo '</table>';
			}
		}

		$con->close();
	}
?>


<!DOCTYPE html>
<html>

<head>
	<link rel="stylesheet" href="css/product_table.css">
</head>

<body>
	<?php
		require("top_nav.php");
	?>

	<div >
		<?php
			getProducts_ForEachCategory();
		?>
	</div>

</body>

</html>