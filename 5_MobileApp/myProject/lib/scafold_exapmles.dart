import 'package:flutter/material.dart';

class scafold_example extends StatelessWidget
{
  const scafold_example({super.key});
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      drawer: Drawer(),
        endDrawer: const Drawer(),
      appBar: AppBar(
        title: Text('Home',
        style: TextStyle(
          fontSize: 28,
          fontWeight: FontWeight.bold,
          color: Colors.white
        ),),
        centerTitle: true,
        elevation: 5,
        leading: Icon(Icons.arrow_back),
        backgroundColor: Colors.blue,
        foregroundColor: Colors.white,
      ),
      body: Center(
        child: Container(
          //color: Colors.greenAccent,
          margin: EdgeInsets.symmetric(vertical: 50, horizontal: 50),
          padding: EdgeInsets.all(40),
          decoration: BoxDecoration(
            gradient: const SweepGradient(
                colors: [
                  Colors.blue,
                  Colors.greenAccent,
                  Colors.red,
                  Colors.yellowAccent,
                ]),
            color: Colors.black,
            boxShadow: const [
              BoxShadow(
                color: Colors.purple,
                blurRadius: 10.0,
                offset: Offset(10, 10)
              ),
            BoxShadow(
              color: Colors.purple,
              blurRadius: 10.0,
              offset: Offset(-10, -10)
            )
            ],
            borderRadius: BorderRadius.circular(50),
          ),
          child: Text(
            'Welcome To Flutter',
            style: TextStyle(
                fontSize: 24,
                fontWeight: FontWeight.bold,
                color: Colors.white
            ),
          ),
        ),
      ),
      backgroundColor: Colors.amber,
      floatingActionButton: Container(
        color: Colors.red,
        height: 80,
        width: 80,
        child: Center(child:  const Text('Press')),
      ),
      bottomNavigationBar: Container(
        color: Colors.blue,
        height: 80,
      ),
      );
  }
}