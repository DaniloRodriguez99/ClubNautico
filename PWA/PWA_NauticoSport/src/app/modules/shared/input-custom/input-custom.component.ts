import { Component, ElementRef, Input, OnInit, Output, ViewChild } from '@angular/core';
import { Genres } from 'src/app/helper/genres';


const INPUT_TYPES = {
  GENRE_SELECT: "genre",
  TEXT: "text",
  PASSWORD: "password"
}

@Component({
  selector: 'app-input-custom',
  templateUrl: './input-custom.component.html',
  styleUrls: ['./input-custom.component.scss']
})
export class InputCustomComponent implements OnInit {

  constructor() { }

  
  select_genre_default_text: string = ""
  genres: string[] = [];

  @Input() type:string = INPUT_TYPES.TEXT;
  @Input() placeholder:string = ''
  @Input() value:any = ''
  
  ngOnInit(): void {
    if(this.type == INPUT_TYPES.GENRE_SELECT)
    {
      this.select_genre_default_text = "inputs.genre.options.default"
      this.genres = this.mapGenres();
    }
  }

  mapGenres = () => {
    let mappedGenres: string[] = [];
    Object.keys(Genres).filter((item) => {
      if (isNaN(Number(item)))
      {
        mappedGenres.push(`inputs.genre.options.${item}`) 
      }
    })
    return mappedGenres;
  }

  setValue = (value: any) => {
    this.value = value;
  }

}


