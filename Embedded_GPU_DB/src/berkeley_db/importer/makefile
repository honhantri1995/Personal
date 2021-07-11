include ../Makefile.in

# Define directories containing libraries other than /usr/lib
#   The rule is appending '-L' before the directory name 
LFLAGS = 

CFLAGS += 
# -DDEBUG
# -DBENCHMARK 

# Define names of libraries to link into executable:
#   The rule is appending '-l' before the lib name 
#   For example, to link in libraries mylib.so or mylib.a, use -lmylib (no extension)
LIBS = -ldb_cxx -lstdc++fs

# Define the C++ source files
SRC_DIR_1 = ./../../common
SRC_DIR_2 = ./
SRC_DIR_3 = ./../com
SRC_DIR_4 = ./../db
SRC_FILES := $(shell find $(SRC_DIR_1) $(SRC_DIR_2) $(SRC_DIR_3) $(SRC_DIR_4) -name '*.cpp')

# Define directories containing header files other than /usr/include
#   The rule is appending '-I' before the directory name 
HEADERS = -I$(SRC_DIR_1) -I$(SRC_DIR_2) -I$(SRC_DIR_3) -I$(SRC_DIR_4)

# Define the executable file's name
EXE = importer

# Running 'make' will invoke the first target entry in the file 
# You can name this target entry anything, but "default" or "all" are the convention
all: $(EXE)
	echo "All source files have been compiled"

# HARD CODE
DO_CREATE_OBJECT_FILES = false
ifeq ($(DO_CREATE_OBJECT_FILES), false)
# Compiling and Linking: Create the executable file from source files
$(EXE):
	$(CC) $(CFLAGS) $(HEADERS) $(SRC_FILES) $(LFLAGS) $(LIBS) -o $(EXE)
else
# Linking: Create the executable file from object files
$(EXE): $(OBJS)
	$(CC) $(CFLAGS) $(HEADERS) $(OBJS) $(LFLAGS) $(LIBS) -o $(EXE)

# Define the C++ object files 
#   This uses Suffix Replacement within a macro: $(name:oldstr=newstr)
#   For each word in 'name', replace 'oldstr' with 'newstr'
# Below we're replacing the suffix .cpp of all words in SRC_FILES with the .o suffix
OBJS = $(SRC_FILES:.cpp=.o)

# Compiling: Create object files from source files
# Below we're using pre-defined macros:
#    '$^' is the list of names of the dependencies (.cpp files)
#    '$@' is the name of the target (.o file) 
.cpp.o:
	$(CC) $(CFLAGS) $(HEADERS) -c $^ -o $@
endif

# Running 'make clean' removes the executable file, all .o files and *~ backup files
clean:
	$(RM) *.o *~ $(EXE)
	$(RM) $(SRC_DIR_2)/*.o
	$(RM) $(SRC_DIR_3)/*.o
	$(RM) $(SRC_DIR_4)/*.o

# Running 'make depend' generates dependencies of Cpp source files automatically
#    Install makedepend on Ubuntu: sudo apt-get install xutils-dev
depend: $(SRC_FILES)
	makedepend $(HEADERS) $^

# DO NOT DELETE THIS LINE -- make depend needs it
