import React from 'react'
import styles from './FocusTimes.module.css'

const FocusTimes = () => {
    const [schedules, setSchedules] = React.useState([]);

    React.useEffect(() => {
        let today = new Date();
        let localStorageKey = "focus-times-" + today.getFullYear() + "-" + today.getMonth() + "-" + today.getDate();
        let todaySchedules = JSON.parse( localStorage.getItem(localStorageKey));

        if (!todaySchedules)
        {
            localStorage.clear();
            fetch("https://localhost:5001/focustimes")
            .then(r => r.json())
            .then(d => {
                todaySchedules = d;
                localStorage.setItem(localStorageKey, JSON.stringify(d));
                setSchedules(todaySchedules);
            });
        } else {

        setSchedules(todaySchedules);
        }
    }, [])

    if (!schedules) return <></>

    let getTodayString = () => {
        let today = new Date();
        return today.getFullYear() + "-" + today.getMonth() + "-" + today.getDate();
    }

   return (
       <div>
           <h1>FocusTimes {getTodayString()}</h1>
           {
            schedules &&
            schedules.length &&
            (
                <table style = {{"width":"30%"}}>
                    <thead>
                        <tr style={{"textAlign":"left"}}>
                            <th>Time</th>
                            <th>Category</th>
                            <th>Topic</th>
                        </tr>
                    </thead>
                    <tbody>
                    {
                        schedules.map((s, index) => {
                            return (
                                <tr style={{"textAlign":"left"}} key={index}>
                                    <td>{s.timeSlot}</td>
                                    <td>{s.categoryName}</td>
                                    <td>{s.topicName}</td>
                                </tr>
                            )
                        })
                    }
                    </tbody>
                </table>
            )
        }
       </div>
   )
}

export default FocusTimes