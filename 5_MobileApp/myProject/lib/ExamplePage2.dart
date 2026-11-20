import 'package:flutter/material.dart';

class Examplepage2 extends StatelessWidget {
  const Examplepage2({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Row & Column Example'),
        backgroundColor: Colors.blue,
      ),
      body: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          Icon(Icons.person, color: Colors.amber,size: 60,),
          Icon(Icons.apple, color: Colors.amber,size: 60,),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [],
          )
        ],
      ),
    );
  }
}
