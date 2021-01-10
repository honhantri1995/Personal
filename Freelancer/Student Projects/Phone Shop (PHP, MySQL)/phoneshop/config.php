<?php
    if (!defined('SERVERNAME')) define('SERVERNAME', 'localhost');
    if (!defined('USERNAME')) define('USERNAME', 'root');
    if (!defined('PASSWORD')) define('PASSWORD', '');
    if (!defined('DATABASE')) define('DATABASE', 'shop');

    // Create connection
    $con = new mysqli(SERVERNAME, USERNAME, PASSWORD, DATABASE);

    // Check connection
    if ($con->connect_error) {
        die("Connection failed: " . $con->connect_error);
    }
?>