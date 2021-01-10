<?php
	function getCategories()
	{
		require("config.php");

		$query = "SELECT * FROM category";
		$result = $con->query($query);

		if ($result == false) {
			echo "ERROR: Get category failed:\n" . $con->error . "\nYour query: " . $query;
			$con->close();
			return "";
		}
	
		$all_rows = array();
		while ($row = $result->fetch_assoc()) {
			array_push($all_rows, $row);
		}
		
		$con->close();
		return $all_rows;
	}
?>


<!DOCTYPE html>
<html>

<head>
	<link rel="stylesheet" href="css/top_nav.css">
</head>

<body>
	<div class="topnav">
		<a href="index.php">Home</a>
		<body> 
    
           
               <?php 
            $conn= mysqli_connect("localhost","root","","shop");
            $sql="SELECT * FROM Category";
            $result=$conn->query($sql);
           
            if($result->num_rows > 0)
            {
                while ($row = $result->fetch_assoc())
                {
                    echo '<a href="category.php?category_id='.$row["id"].'">'.$row["name"].'</a>';
                }
            }
           ?>    
		<a href="login.php">Login</a>
	</div>

</body>

</html>