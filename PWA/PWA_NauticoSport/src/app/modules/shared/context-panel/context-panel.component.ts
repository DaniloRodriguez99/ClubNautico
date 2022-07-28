import { Component, HostListener, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-context-panel',
  templateUrl: './context-panel.component.html',
  styleUrls: ['./context-panel.component.scss']
})
export class ContextPanelComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    this.setPanelSizeByWindowsSize();
  }

  filtersModal : HTMLElement | null = null;
  scrHeight = 0;
  scrWidth = 0;
  isTabletSizeOrLess: boolean = false;
  isClosed = true;
  isRecentlyOpened = false;
  
  //Detect if the user has clicked out of the panel, in this case the panel will be closed
  clickedOutside = (event: any) => {
    let isInside = (element: any) : boolean => {
      if (element == undefined)
      {
        return false;
      }
      else {
        if (element == this.filtersModal)
        {
          return true;
        } else {
          return isInside(element.parentElement);
        }
      }
    };

    if( !isInside(event.target) && !this.isRecentlyOpened) {
      this.closeModal();
    }
    this.isRecentlyOpened = false;
  };

  activeModal = (element: HTMLElement) => {
    if(this.filtersModal == undefined) {
      this.filtersModal = document.getElementById("filtersModal");
    }
    if(this.filtersModal != undefined){
      this.getOffset(element)
      this.filtersModal.classList.remove("closed")
      this.changePanel()
      this.isRecentlyOpened = true;
      document.addEventListener("click", this.clickedOutside) // Start to listen the DOM click events in the function clickedOutside()
    }
  }

  // Manage the changes of windows size, and in function of it will change the panel
  @HostListener('window:resize', ['$event'])
  setPanelSizeByWindowsSize(event? : any) {
        this.scrHeight = window.innerHeight;
        this.scrWidth = window.innerWidth;
        this.isTabletSizeOrLess = this.scrWidth <= 800;   
        this.changePanel() 
  }
  
  // Change the contex panel style, form tablet to less size devices the panel
  // will become in a modal popup, and in web is a context panel
  changePanel() {
    if(this.filtersModal != undefined){
        let newClass = this.isTabletSizeOrLess ? "filterModalPopUpActive" : "filterContextPanelActive";
        this.filtersModal.classList.remove( newClass == "filterContextPanelActive" ? "filterModalPopUpActive" : "filterContextPanelActive" )
        this.filtersModal.classList.add(newClass)
    }
  }

  closeModal = () => {
    if(this.filtersModal != undefined){
        let activedClass = this.filtersModal.classList.contains("filterContextPanelActive") ? "filterContextPanelActive" : "filterModalPopUpActive";
        this.filtersModal.classList.remove(activedClass)
        this.filtersModal.classList.add("closed")
        document.removeEventListener('click', this.clickedOutside); //When we close the panel we dont need be listening the events, this improve the app's performance
    }
  }

  // Put the panel just in the same place of the element that has called the panel
  private getOffset = (element: HTMLElement) => {
    if(this.filtersModal != undefined){
      if(!this.isTabletSizeOrLess){
        const rect = element.getBoundingClientRect();
        this.filtersModal.style.left = (rect.left + window.scrollX + rect.width).toString() + "px"
        this.filtersModal.style.top = (rect.top + window.scrollY + rect.height/2).toString() + "px"
      }
    } 
    
  }

  ngOnDestroy() {
    document.removeEventListener('click', this.clickedOutside); // When the panel is not used we dont need be listening event here, this improve the app's performance
  }
}
