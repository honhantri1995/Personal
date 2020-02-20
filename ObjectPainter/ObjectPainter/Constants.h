/**
*  @file   Constant.h
*  @brief  This file defines all constants used in other files
*  @author Tri Ho
*  @date   Dec 21, 2018
**/

#pragma once

// Control IDs
enum class UIID {
	DRAWING_AREA,
	EDITTING_AREA,
	APPLY_BTN,
	LOADFILE_BTN,
	SAVEFILE_BTN,
	EXIT_BTN
};

// Names of shape properties
#define NAME			"name"
#define TYPE			"type"
#define X0				"x0"
#define Y0				"y0"
#define X1				"x1"
#define Y1				"y1"
#define X2				"x2"
#define Y2				"y2"
#define HEIGHT			"height"
#define WIDTH			"width"
#define PENTHICKNESS	"pen_thickness"
#define PENCOLOR		"pen_color"
#define FILLCOLOR		"fill_color"

// Names of shapes
#define RECTANGLE		"rectangle"
#define LINE			"line"
#define TRIANGLE		"triangle"
#define ELLIPSE			"ellipse"

// Names of colors
#define BLACK			"black"
#define GREEN			"green"
#define BLUE			"blue"
#define RED				"red"
#define BROWN			"brown"

// // Number of shape types
// #define NUMBER_OF_SHAPE 4

// // Number of colors
// #define NUMBER_OF_COLOR 5

// Button dimemsions
#define BUTTON_WIDTH	45
#define BUTTON_HEIGHT	25

// // Maximum length of message
// const int MAX_MESSAGE_LENGTH = 200;
