import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{

  public homeText: string;

  constructor(){}


  // Lazy load
  ngOnInit(): void{
    this.homeText = "Bem Vindo a Aplicaçãp Account-Owner";
  }
}
