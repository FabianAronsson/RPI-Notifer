#include <iostream>
#include "led-matrix.h"

using rgb_matrix::RGBMatrix;

int main(int argc, char** argv) {
	std::cout << "Startup";
	RGBMatrix::Options my_defaults;
	my_defaults.hardware_mapping = "regular";  // or e.g. "adafruit-hat" or "adafruit-hat-pwm"
	my_defaults.chain_length = 3;
	my_defaults.show_refresh_rate = true;
	rgb_matrix::RuntimeOptions runtime_defaults;
	// If you drop privileges, the root user you start the program with
	// to be able to initialize the hardware will be switched to an unprivileged
	// user to minimize a potential security attack surface.
	runtime_defaults.drop_privileges = 1;
	RGBMatrix* matrix = RGBMatrix::CreateFromFlags(&argc, &argv,
		&my_defaults,
		&runtime_defaults);
	if (matrix == NULL) {
		std::cout << "Matrix is null";
		PrintMatrixFlags(stderr, my_defaults, runtime_defaults);
		return 1;
	}

	// matrix->ApplyPixelMapper(...);  // Optional

	// Do your own command line handling with the remaining options.

	//  .. now use matrix
	std::cout << "Matrix is READY";
	delete matrix;   // Make sure to delete it in the end.
}