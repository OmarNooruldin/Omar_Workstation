import 'package:flutter/material.dart';

class Examplepages1 extends StatelessWidget {
  const Examplepages1({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Center(
            child: Image.asset('assets/Images/flutter.jpg',
              width: 250,
              height: 250,
            ),
          ),
          Center(
            child: Image.network('https://unsplash.com/photos/empire-state-building-in-new-york-city-mFjzQgNtXLU',
              width: 250,
              height: 250,
            ),
          )
        ],
      ),
    );
  }
}
