import React, { Dispatch, useState } from "react";
import { AppState } from "../reducers/rootReducer";
import { ShelterCardPreview } from "../components/ShelterCardPreview";
import { connect } from "react-redux";
import { fetchShelters } from "../actions/shelterActions";
import '../styles/search.scss';

const ShelterList: React.FC<Props> = ({ shelters, fetch, loading }) => {
    const [isLoading, setIsLoading] = useState<boolean>(false);
      
      if(!isLoading){
        fetch();
        setIsLoading(true);
      }

    return (
        <div className="container">
            <div className="row">
                <div  className="input-field ">
                    <i className="material-icons prefix">search</i><input type="search" name="" id="search" placeholder="Search..." />
                </div>
            </div>
            {
                loading == false ? (
                    <div className="row">
                        {                    
                            shelters.length == 0 ? (
                                <h3>Sorry. Couldn't find any shelter :(</h3>
                            )
                                :
                                (
                                    shelters.map(x => {
                                        return (
                                            <ShelterCardPreview card={x} key={x.id}></ShelterCardPreview>
                                        )
                                    })
                                )
                        }
                    </div>
                ) : (
                        <div className="container">
                            <div className="progress">
                                <div className="indeterminate"></div>
                            </div>
                        </div>
                    )
            }
        </div>
    )
}

const mapStateToProps = (state: AppState) => {
    return {
        shelters: state.shelters.shelters,
        loading: state.app.loading
    }
}

const mapDispatchToProps = (dispatch: Dispatch<any>) => ({
    fetch: () => {
        dispatch(fetchShelters());
    }
})


type Props = ReturnType<typeof mapStateToProps> & ReturnType<typeof mapDispatchToProps>;

export default connect(mapStateToProps, mapDispatchToProps)(ShelterList);