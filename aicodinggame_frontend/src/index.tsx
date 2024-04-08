import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import RobotElement from './components/RobotElement';
import reportWebVitals from './reportWebVitals';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

const robots = [
    {
        name: "Listik",
        statistic: {
            winnerPercent: 0.25,
            kills: 25
        }
    },
    {
        name: "Drakonyashka",
        statistic: {
            winnerPercent: 0.57,
            kills: 25
        }
    },
    {
        name: "Turtle",
        statistic: {
            winnerPercent: 0.17,
            kills: 4    
        }
    }
]


root.render(
  <React.StrictMode>
      {robots.map((robot) =>
          <RobotElement
              name={robot.name}
              statistic = {{ 
                  winPercent: robot.statistic.winnerPercent,
                  totalKillsCount: robot.statistic.kills
              }}
              battles={ [] }
          ></RobotElement>
      )}
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
