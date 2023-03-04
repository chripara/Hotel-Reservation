import React, { useState } from "react";
import { View, StyleSheet, Text, TextInput } from "react-native";
import { MainScreen } from "../MainScreen";
import colors from "../../config/colors";
import { EllipseButtonPrimary } from "../../components/EllipseButtonPrimary";
import { CalendarInput } from "../../components/CalendarInput";
import defaultStyles from "../../config/defaultStyles";

export const BookingUpdateScreen = ({ navigation }) => {
    const [checkInDate, setCheckInDate] = useState(new Date());
    const [checkOutDate, setCheckOutDate] = useState(new Date());

    return(
        <MainScreen backgroundColor={colors.secondary}>
            <View style={styles.container}>
                <View style={styles.viewText}>
                    <Text style={defaultStyles.text36White}>Bookings</Text>
                </View>
                <View style={styles.viewText}>
                    <Text style={defaultStyles.text20White}>Hotel Name:</Text>
                    <TextInput style={defaultStyles.textInput} value={'Lake Place Inn'}/>
                    <Text style={defaultStyles.text20White}>Room:</Text>
                    <TextInput style={defaultStyles.textInput} value={'506'}/>
                    <Text style={defaultStyles.text20White}>Cost:</Text>
                    <TextInput style={defaultStyles.textInput} value={'300 €'}/>
                    <Text style={defaultStyles.text20White}>Check In:</Text>
                    <CalendarInput date={checkInDate} setDate={setCheckInDate} />
                    <Text style={defaultStyles.text20White}>Check Out:</Text>
                    <CalendarInput date={checkOutDate} setDate={setCheckOutDate}/>
                    <Text style={defaultStyles.text20White}>Description:</Text>
                    <TextInput style={styles.textInput} multiline={true} value={`Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type.`}/>
                </View>
                <EllipseButtonPrimary
                    name={"Create Booking"}
                    onClick={() => console.log('Create Booking')}//navigation.navigate("ChangeEmail")}
                    marginTop={"1.5%"}
                />
            </View>
        </MainScreen>
    )
};

const styles = StyleSheet.create({
    container: {
        flex: 1,
        padding: "3%",
    },
    viewText: {
        position: "relative",
        marginVertical: "2%",
        paddingHorizontal: "5%",
    },
    textInput: {
        height: 120,
        textAlign: "left",
        textAlignVertical: 'top',
        fontFamily: "Italiana-Regular",
        fontSize: 20,
        backgroundColor: colors.light,
        paddingLeft: "4%",
        borderRadius: 5,
        paddingVertical: 10
    }
});
