
  export class Tag {
    id: number;
    name: string;
    nbXPosts: number;
    isChecked: boolean;
    body: string;
    timestamp: string;
    
    constructor(data: any) {
      if(data) {
        this.id = data.id;
        this.name = data.name;
        this.nbXPosts = data.nbXPosts;
        this.isChecked = false;
        this.body = data.body;
        this.timestamp = data.timestamp;
      }
    }
  }

   