import axios from 'axios';
import { useEffect, useState } from 'react';
import { Header, List, ListContent, ListIcon, ListItem } from 'semantic-ui-react';



//when this loads, I want to create my states from my API
function App() {

//going to use a react hook to remember any data we made to our API.
  const [activities, setActivites] = useState([]);

//to add a side effect to our component, we use the useEffect hook
//basically sauys, when this component loads, do this
useEffect(() => {
  axios.get('http://localhost:5000/api/activities')
    .then(response => {
      setActivites(response.data);
    })
}, []) //this empty array is a dependency array, it says, only run this effect when the component mounts

  return (
    <div>
     <Header as='h2' icon='twitter' content='Reactivities'></Header>
        <List>
          {activities.map((activity: any) => (
            <ListItem key={activity.id}>
              <ListIcon name='github' size='large' verticalAlign='middle' />
              <ListContent>{activity.title}</ListContent>
            </ListItem>
          ))}
      </List>
    </div>
  )
}

export default App
