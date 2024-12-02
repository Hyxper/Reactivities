import axios from 'axios';
import { useEffect, useState } from 'react';



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
      <h1>App</h1>
        <ul>
          {activities.map((activity: any) => (
            <li key={activity.id}>{activity.title}</li>
          ))}
      </ul>
    </div>
  )
}

export default App
