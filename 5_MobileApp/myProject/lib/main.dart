import 'package:flutter/material.dart';
import 'package:myproject/ExamplePage1.dart';
import 'package:myproject/scafold_exapmles.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget
{
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Flutter App',
      home: Examplepages1(),
    );
  }
}

